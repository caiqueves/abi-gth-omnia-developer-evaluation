using MediatR;
using AutoMapper;
using Newtonsoft.Json;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleComand,CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ISaleCreatedEventService _saleCreatedEventService;
    //private readonly IRedisService _redisService;


    public CreateSaleCommandHandler(ISaleRepository SaleRepository, IMapper mapper, ISaleCreatedEventService saleCreatedEventService /*, IRedisService redisService,*/)
    {
        _saleRepository = SaleRepository;
        _mapper = mapper;
        _saleCreatedEventService = saleCreatedEventService;
        ////_redisService = redisService;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleComand request, CancellationToken cancellationToken)
    {
        try
        {
            var sale = new Sale(request.SaleDate, request.CustomerId!, request.BranchId);

            foreach(var item in request.SaleItems! ) 
            {
                sale.AddItem(item.ProductName!, item.Quantity, item.UnitPrice);
            }
           
            ////{
            ////    Id = IdSale,
            ////    DataVenda = request.DataVenda,
            ////    ClienteId = request.ClienteId,
            ////    //FilialId = request.FilialId,
            ////    VendaProdutos = request.ItensVenda!.Select(i =>

            ////    {

            ////        // Aplica a limitação de 20 itens
            ////        var quantidade = i.Quantidade > 20 ? 20 : i.Quantidade;

            ////        if (quantidade > 20)
            ////            throw new Exception("Não é possivel vende mais que 20 itens");

                   

            ////        // Calcula o desconto baseado na quantidade
            ////        decimal desconto = 0;
            ////        if (quantidade >= 4 && quantidade < 10)
            ////        {
            ////            desconto = 0.10m; // 10% de desconto
            ////        }
            ////        else if (quantidade >= 10 && quantidade <= 20)
            ////        {
            ////            desconto = 0.20m; // 20% de desconto
            ////        }

            ////        // Calcula o valor total por produto
            ////        decimal valorUnitarioComDesconto = product!.Price * (1 - desconto);
            ////        decimal valorTotalProduto = quantidade * valorUnitarioComDesconto;

            ////        // Atualiza o valor total da venda
            ////        valorTotal += valorTotalProduto;
                    
            ////        var newAmount = product.Amount - i.Quantidade;
            ////        _productRepository.UpdateAmountAsync(product.Id, newAmount, cancellationToken);

            ////        // Retorna o objeto de VendaProduto com os valores calculados
            ////        return new VendaProduto
            ////        {
            ////            VendaId = IdVenda,
            ////            ProdutoId = i.ProductId,
            ////            Quantidade = quantidade,
            ////            PrecoUnitario = product!.Price,
            ////            Desconto = desconto * 100, // Desconto em % para salvar
            ////            ValorTotal = valorTotalProduto
            ////        };

            ////    }).ToList(),
            ////    ValorTotal = valorTotal
            ////};

            await _saleRepository.AddAsync(sale);

            var saleCreatedEvent = new SaleCreatedEvent(
                sale.Id,
                request.CustomerId!,
                request.BranchId,
                sale.TotalAmount,
                sale.SaleDate,
                sale.Items.ToList()
                );


            _saleCreatedEventService.PublishSaleCreatedEvent(saleCreatedEvent);

            ////_redisService.SetCache($"sale: {venda.Id}", JsonConvert.SerializeObject(request));

            return _mapper.Map<CreateSaleResult>(saleCreatedEvent);
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possivel criar a venda", ex);
        }
    }
}
