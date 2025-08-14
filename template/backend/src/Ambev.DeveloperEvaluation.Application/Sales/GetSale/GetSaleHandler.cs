using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleComand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    ////private readonly IRedisService _redisService;


    public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper/*, IRedisService redisService*/)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        //_redisService = redisService;
    }

    public async Task<GetSaleResult> Handle(GetSaleComand command, CancellationToken cancellationToken)
    {
        //var sale = new Sale();
        ////var vendaJson = _redisService.GetCache($"sale:{command.Id}");

        //if (vendaJson != null)
        //{
        //    venda = JsonConvert.DeserializeObject<Venda>(vendaJson);
        //}
        //else
        //{
        var sale = _saleRepository.GetByIdAsync(command.Id).Result;

        if (sale == null)
            throw new KeyNotFoundException($"Not possible get sale. Because not found sale for {command.Id}");

        //_redisService.SetCache($"sale: {venda.Id}",JsonConvert.SerializeObject(venda));

        //var getSaleDto = new GetSaleDto(venda.Id, venda.ClienteId, Guid.Empty, venda.ValorTotal, venda.DataVenda,
        //    venda.VendaProdutos!.Select(i => new SaleItemDto
        //    {
        //        ProductId = i.ProdutoId,
        //        Quantidade = i.Quantidade

        //    }).ToList()
        //);

        return _mapper.Map<GetSaleResult>(new GetSaleResult { CustomerId = sale.CustomerId, SaleDate = sale.SaleDate, Id = sale.Id, SaleItems = sale.Items.ToList(), BranchId = sale.BranchId, SaleNumber = sale.SaleNumber });
    }
}
