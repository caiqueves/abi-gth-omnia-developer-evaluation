using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;


namespace Ambev.DeveloperEvaluation.Application.Vendas.ObterVenda;

public class ObterVendaCommandHandler : IRequestHandler<ObterVendaCommand, ObterVendaResult>
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;


    public ObterVendaCommandHandler(IVendaRepository vendaRepository, IMapper mapper, IRedisService redisService)
    {
        _vendaRepository = vendaRepository;
        _mapper = mapper;
        _redisService = redisService;
    }

    public async Task<ObterVendaResult> Handle(ObterVendaCommand command, CancellationToken cancellationToken)
    {
        var venda = new Venda();
        var vendaJson = _redisService.GetCache($"sale:{command.Id}");

        if (vendaJson != null)
        {
            venda = JsonConvert.DeserializeObject<Venda>(vendaJson);
        }
        else
        {
            venda = _vendaRepository.ObterVendaAsync(command.Id).Result;

            if (venda == null)
            {
                throw new KeyNotFoundException($"Not possible get sale. Because not found sale for {command.Id}");
            }

        }
        //_redisService.SetCache($"sale: {venda.Id}",JsonConvert.SerializeObject(venda));

        var getSaleDto = new GetSaleDto(venda.Id, venda.ClienteId, Guid.Empty, venda.ValorTotal, venda.DataVenda,
            venda.VendaProdutos!.Select(i => new SaleItemDto
            {
                ProductId = i.ProdutoId,
                Quantidade = i.Quantidade

            }).ToList()
        );

        return _mapper.Map<ObterVendaResult>(getSaleDto);
    }
}
