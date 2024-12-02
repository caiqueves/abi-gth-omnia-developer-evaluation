using Ambev.DeveloperEvaluation.Application.Event;
using Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CancelarItemVenda;

//public class CancelarItemVendaCommandHandler : IRequestHandler<CancelarItemVendaCommand, CancelarItemVendaResult>
//{
    //private readonly IVendaRepository _vendaRepository;
    //private readonly IMapper _mapper;
    //private readonly IRedisService _redisService;
    //private readonly EventService _eventService;
    //private readonly IVendaProdutoRepository _vendaProdutoRepository;
    //private readonly IProductRepository _productRepository;

    //public CancelarItemVendaCommandHandler(IVendaRepository vendaRepository, IMapper mapper, IRedisService redisService, EventService eventService,
    //     IVendaProdutoRepository vendaProdutoRepository, IProductRepository productRepository)
    //{
    //    _vendaRepository = vendaRepository;
    //    _mapper = mapper;
    //    _redisService = redisService;
    //    _eventService = eventService;
    //    _vendaProdutoRepository = vendaProdutoRepository;
    //    _productRepository = productRepository;
    //}

    //public async Task<CancelarItemVendaResult> Handle(CancelarItemVendaCommand request, CancellationToken cancellationToken)
    //{
    //    //var itemVenda = await _vendaProdutoRepository.GetByVendaIdAsync(request.VendaId)
    //    //    .FirstOrDefaultAsync(iv => iv.VendaId == request.VendaId && iv.Id == request.ItemVendaId, cancellationToken);

    //    //if (itemVenda == null)
    //    //{
    //    //    throw new KeyNotFoundException("Item de venda não encontrado.");
    //    //}

    //    //itemVenda.Desconto = 0;
    //    //itemVenda.ValorTotal = 0;

    //    //_contexto.ItensVenda.Update(itemVenda);
    //    //await _contexto.SaveChangesAsync(cancellationToken);

    //    //return true;
    //}
//}
