using Ambev.DeveloperEvaluation.Application.Event;
using Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;
using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;

public class AtualizarVendaCommandHandler : IRequestHandler<AtualizarVendaComand, AtualizarVendaResult>
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;
    private readonly EventService _eventService;
    private readonly IVendaProdutoRepository _vendaProdutoRepository;
    private readonly IProductRepository _productRepository;

    public AtualizarVendaCommandHandler(IVendaRepository vendaRepository, IMapper mapper, IRedisService redisService, EventService eventService,
        IVendaProdutoRepository vendaProdutoRepository, IProductRepository productRepository)
    {
        _vendaRepository = vendaRepository;
        _mapper = mapper;
        _redisService = redisService;
        _eventService = eventService;
        _vendaProdutoRepository = vendaProdutoRepository;
        _productRepository = productRepository;
    }

    public async Task<AtualizarVendaResult> Handle(AtualizarVendaComand request, CancellationToken cancellationToken)
    {
        decimal valorTotal = 0;
        var vendaExistente = _vendaRepository.ObterVendaAsync(request.Id).Result;

        if (vendaExistente == null)
        {
            throw new KeyNotFoundException($"Sale not found for Id {request.ClienteId}");
        }

        // Atualizar dados da venda
        vendaExistente.DataVenda = request.DataVenda;
        vendaExistente.ClienteId = request.ClienteId;
        //vendaExistente.FilialId = request.FilialId;

        // Atualizar itens da venda
        vendaExistente.VendaProdutos = request!.ItensVenda!.Select(i =>
        {

            if (i.Quantidade > 20)
                throw new Exception("Não é possivel vende mais que 20 itens");

            var product = _productRepository.GetByIdAsync(i.ProductId).Result;

            if(product is null)
                throw new Exception($"Not found registry for Id: {i.ProductId}.");

            // Verificar a quantidade anterior (quantidade do produto na venda existente)
            var vendaProdutoExistente = vendaExistente!.VendaProdutos!.FirstOrDefault(p => p.ProdutoId == i.ProductId);
            if (vendaProdutoExistente != null)
            {
                // Se a quantidade foi alterada, ajustar o estoque
                var quantidadeAnterior = vendaProdutoExistente.Quantidade;
                if (i.Quantidade > quantidadeAnterior)
                {
                    // Se a quantidade foi aumentada, reduz o estoque
                    var novoEstoque = product.Amount - (i.Quantidade - quantidadeAnterior);
                    if (novoEstoque < 0)
                        throw new Exception($"Estoque insuficiente para a quantidade solicitada. Apenas {product.Amount} estão disponíveis.");

                    // Atualiza o estoque
                    _productRepository.UpdateAmountAsync(product.Id, novoEstoque, cancellationToken);
                }
                else if (i.Quantidade < quantidadeAnterior)
                {
                    // Se a quantidade foi diminuída, aumenta o estoque
                    var novoEstoque = product.Amount + (quantidadeAnterior - i.Quantidade);

                    if (novoEstoque < 0)
                        throw new Exception($"Estoque insuficiente para a quantidade solicitada. Apenas {product.Amount} estão disponíveis.");
                    _productRepository.UpdateAmountAsync(product.Id, novoEstoque, cancellationToken);
                }
            }

            // Calcula o desconto baseado na quantidade
            decimal desconto = 0;
            if (i.Quantidade >= 4 && i.Quantidade < 10)
            {
                desconto = 0.10m; // 10% de desconto
            }
            else if (i.Quantidade >= 10 && i.Quantidade <= 20)
            {
                desconto = 0.20m; // 20% de desconto
            }

            // Calcula o valor total por produto
            decimal valorUnitarioComDesconto = product!.Price * (1 - desconto);
            decimal valorTotalProduto = i.Quantidade * valorUnitarioComDesconto;

            // Atualiza o valor total da venda
            valorTotal += valorTotalProduto;

            // Retorna o objeto de VendaProduto com os valores calculados
            var vendaProduto = new VendaProduto
            {
                VendaId = vendaExistente.Id,
                ProdutoId = i.ProductId,
                Quantidade = i.Quantidade,
                PrecoUnitario = product!.Price,
                Desconto = desconto * 100, // Desconto em % para salvar
                ValorTotal = valorTotalProduto
            };

            return vendaProduto;

        }).ToList();
        vendaExistente.ValorTotal = valorTotal;

        await _vendaRepository.AtualizarVendaAsync(request.Id,vendaExistente);

        var saleModifiedEvent = new SaleModifiedEvent(
                vendaExistente.Id,
                request.ClienteId,
                Guid.Empty,
                valorTotal,
                request.DataVenda,

            request.ItensVenda!.Select(i => new SaleItemDto
            {
                ProductId = i.ProductId,
                Quantidade = i.Quantidade

            }).ToList()
        );

        _eventService.PublishSaleModifiedEvent(saleModifiedEvent);

        _redisService.SetCache($"sale: {vendaExistente.Id}", JsonConvert.SerializeObject(saleModifiedEvent));

        return _mapper.Map<AtualizarVendaResult>(saleModifiedEvent);
    }
}
