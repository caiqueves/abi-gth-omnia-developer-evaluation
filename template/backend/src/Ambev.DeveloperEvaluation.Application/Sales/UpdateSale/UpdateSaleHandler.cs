using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleComand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ISaleModifiedEventService _saleModifiedEventService;
    //private readonly IRedisService _redisService;


    public UpdateSaleCommandHandler(ISaleRepository SaleRepository, IMapper mapper, ISaleModifiedEventService saleModifiedEventService /*, IRedisService redisService,*/)
    {
        _saleRepository = SaleRepository;
        _mapper = mapper;
        _saleModifiedEventService = saleModifiedEventService;
        ////_redisService = redisService;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleComand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id);
        if (sale == null)
            throw new KeyNotFoundException($"Sale not found for Id {request.Id}");

        if (sale.IsCancelled)
            throw new ApplicationException($"Sale for Id {sale.Id} have status {request.IsCancelled}");

        // Atualiza cabeçalho
        sale.UpdateHeader(request.SaleDate, request.CustomerId, request.BranchId);

        foreach (var requestItem in request.SaleItems ?? Enumerable.Empty<SaleItem>())
        {
            if (requestItem.Id != Guid.Empty)
            {
                // Cancelar item existente
                if (requestItem.IsCancelled)
                {
                    var existingItem = sale.Items.FirstOrDefault(i => i.Id == requestItem.Id);

                    if (existingItem != null && !existingItem.IsCancelled) // só cancela se ainda não estiver cancelado
                    {
                        sale.CancelItem(requestItem.Id);
                    }

                }
                else
                {
                    // Atualizar item existente
                    var existingItem = sale.Items.FirstOrDefault(i => i.Id == requestItem.Id);
                    if (existingItem != null)
                    {
                        bool changed =
                            existingItem.Quantity != requestItem.Quantity ||
                            existingItem.UnitPrice != requestItem.UnitPrice ||
                            existingItem.ProductName != requestItem.ProductName;

                        if (changed)
                        {
                            sale.UpdateItem(
                                requestItem.Id,
                                requestItem.ProductName ?? string.Empty,
                                requestItem.Quantity,
                                requestItem.UnitPrice
                            );
                        }
                    }
                    else
                    {
                        // Item informado mas não encontrado na venda → adicionar
                        sale.AddItem(
                            requestItem.ProductName ?? string.Empty,
                            requestItem.Quantity,
                            requestItem.UnitPrice
                        );
                    }
                }
            }
            else
            {
                // Adicionar novo item (ignorar se marcado como cancelado)
                if (!requestItem.IsCancelled)
                {
                    sale.AddItem(
                        requestItem.ProductName ?? string.Empty,
                        requestItem.Quantity,
                        requestItem.UnitPrice
                    );
                }
            }
        }

        await _saleRepository.UpdateAsync(sale);

        var saleModifiedEvent = new SaleModifiedEvent(
            sale.Id,
            sale.CustomerId,
            sale.BranchId,
            sale.TotalAmount,
            sale.SaleDate,
            sale.Items.ToList()
        );

        _saleModifiedEventService.PublishSaleModifiedEvent(saleModifiedEvent);

        return _mapper.Map<UpdateSaleResult>(sale);
    }

}
