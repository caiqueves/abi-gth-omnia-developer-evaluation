using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Event;
using Ambev.DeveloperEvaluation.Domain.Services;
using Newtonsoft.Json;
using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;

public class CriarVendaCommandHandler : IRequestHandler<CriarVendaCommand,CriarVendaResult>
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;
    private readonly EventService _eventService;
    private readonly IVendaProdutoRepository _vendaProdutoRepository;
    private readonly IProductRepository _productRepository;

    public CriarVendaCommandHandler(IVendaRepository vendaRepository, IMapper mapper, IRedisService redisService, EventService eventService, 
        IVendaProdutoRepository vendaProdutoRepository, IProductRepository productRepository)
    {
        _vendaRepository = vendaRepository;
        _mapper = mapper;
        _redisService = redisService;
        _eventService = eventService;
        _vendaProdutoRepository = vendaProdutoRepository;
        _productRepository = productRepository;
    }

    public async Task<CriarVendaResult> Handle(CriarVendaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            
            decimal valorTotal = 0;
            var IdVenda = Guid.NewGuid();
            var product = new Product();

            var venda = new Venda
            {
                Id = IdVenda,
                DataVenda = request.DataVenda,
                ClienteId = request.ClienteId,
                //FilialId = request.FilialId,
                VendaProdutos = request.ItensVenda!.Select(i =>

                {

                    // Aplica a limitação de 20 itens
                    var quantidade = i.Quantidade > 20 ? 20 : i.Quantidade;

                    if (quantidade > 20)
                        throw new Exception("Não é possivel vende mais que 20 itens");

                    product = _productRepository.GetByIdAsync(i.ProductId).Result;

                    if (product!.Amount < quantidade)
                        throw new Exception($"Não é possível vender a quantidade {quantidade}. Pois só tem disponível {product.Amount}.");

                    // Calcula o desconto baseado na quantidade
                    decimal desconto = 0;
                    if (quantidade >= 4 && quantidade < 10)
                    {
                        desconto = 0.10m; // 10% de desconto
                    }
                    else if (quantidade >= 10 && quantidade <= 20)
                    {
                        desconto = 0.20m; // 20% de desconto
                    }

                    // Calcula o valor total por produto
                    decimal valorUnitarioComDesconto = product!.Price * (1 - desconto);
                    decimal valorTotalProduto = quantidade * valorUnitarioComDesconto;

                    // Atualiza o valor total da venda
                    valorTotal += valorTotalProduto;
                    
                    var newAmount = product.Amount - i.Quantidade;
                    _productRepository.UpdateAmountAsync(product.Id, newAmount, cancellationToken);

                    // Retorna o objeto de VendaProduto com os valores calculados
                    return new VendaProduto
                    {
                        VendaId = IdVenda,
                        ProdutoId = i.ProductId,
                        Quantidade = quantidade,
                        PrecoUnitario = product!.Price,
                        Desconto = desconto * 100, // Desconto em % para salvar
                        ValorTotal = valorTotalProduto
                    };

                }).ToList(),
                ValorTotal = valorTotal
            };

            await _vendaRepository.CriarVendaAsync(venda);

            var saleCreatedEvent = new SaleCreatedEvent(
                IdVenda,
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
            
            _eventService.PublishSaleCreatedEvent(saleCreatedEvent);

            _redisService.SetCache($"sale: {venda.Id}", JsonConvert.SerializeObject(request));

            return _mapper.Map<CriarVendaResult>(saleCreatedEvent);
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possivel criar a venda", ex);
        }
    }
}
