using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelarVendaCommandHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ISaleCancelledEventService _saleCancelledEventService;
    ////private readonly IRedisService _redisService;


    public CancelarVendaCommandHandler(ISaleRepository saleRepository, IMapper mapper, ISaleCancelledEventService saleCancelledEventService /*, IRedisService redisService*/)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _saleCancelledEventService = saleCancelledEventService;
        ////_redisService = redisService;
    }

    public async Task<CancelSaleResult> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {

        var sale = await _saleRepository.GetByIdAsync(request.Id);

        if (sale == null)
            throw new KeyNotFoundException($"Not possible cancelled sale. Because not found sale for {request.Id}");

        if (sale.IsCancelled == true)
            throw new InvalidOperationException($"Not possible cancelled sale. Because in sale with status cancelada");

        sale.Cancel();

        await _saleRepository.UpdateAsync(sale);

        var saleCancelledEvent = new SaleCancelledEvent(
                sale.Id,
                sale.CustomerId,
                sale.BranchId,
                sale.TotalAmount,
                sale.SaleDate,
                sale.Items.ToList(), 
                String.Empty);

        _saleCancelledEventService.PublishSaleCancelledEvent(saleCancelledEvent);

        //_redisService.RemoveCache($"sale: {venda.Id}");

        return _mapper.Map<CancelSaleResult>(saleCancelledEvent);
    }
}
