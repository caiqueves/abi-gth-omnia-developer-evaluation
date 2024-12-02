using Ambev.DeveloperEvaluation.Application.Event;
using Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;
using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;


namespace Ambev.DeveloperEvaluation.Application.Vendas.CancelarVenda;

public class CancelarVendaCommandHandler : IRequestHandler<CancelarVendaCommand, CancelarVendaResult>
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;
    private readonly EventService _eventService;


    public CancelarVendaCommandHandler(IVendaRepository vendaRepository, IMapper mapper, IRedisService redisService, EventService eventService)
    {
        _vendaRepository = vendaRepository;
        _mapper = mapper;
        _redisService = redisService;
        _eventService = eventService;
    }

    public async Task<CancelarVendaResult> Handle(CancelarVendaCommand request, CancellationToken cancellationToken)
    {

        var venda = _vendaRepository.ObterVendaAsync(request.Id).Result;

        if (venda == null)
        {
            throw new KeyNotFoundException($"Not possible cancelled sale. Because not found sale for {request.Id}");
        }

        venda.Cancelado = true;
        await _vendaRepository.AtualizarVendaAsync(request.Id,venda);

        var saleCancelledEvent = new SaleCancelledEvent(
                venda.Id,
                venda.ClienteId,
                Guid.Empty,
                venda.ValorTotal,
                venda.DataVenda,

            venda.VendaProdutos!.Select(i => new SaleItemDto
            {
                ProductId = i.ProdutoId,
                Quantidade = i.Quantidade

            }).ToList(),
            "Venda Cancelada"
        );

        _eventService.PublishSaleCancelledEvent(saleCancelledEvent);

        _redisService.RemoveCache($"sale: {venda.Id}");

        return _mapper.Map<CancelarVendaResult>(saleCancelledEvent);
    }
}
