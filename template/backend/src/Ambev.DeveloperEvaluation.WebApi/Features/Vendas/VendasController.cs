using Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;
using Ambev.DeveloperEvaluation.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.AtualizarVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CriarVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.DeleteSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cars;


[ApiController]
[Route("api/[controller]")]
public class VendasController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public VendasController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CriarVendaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarVenda([FromBody] CriarVendaRequest request, CancellationToken cancellationToken)
    {
        var validator = new CriarVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CriarVendaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponse
        {
            //Success = true,
            //Message = "User created successfully",
            Data = _mapper.Map<CriarVendaResponse>(response)
        });

    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<CriarVendaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtualizarVenda(Guid id, [FromBody] AtualizarVendaRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var validator = new AtualizarVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<AtualizarVendaComand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        
        var venda = await _mediator.Send(request,cancellationToken);
        return Ok(venda);
    }

    ////[HttpDelete("{id}")]
    ////public async Task<IActionResult> CancelarVenda(Guid id)
    ////{
    ////    var command = new CancelarVendaCommand { VendaId = id };
    ////    var sucesso = await _mediator.Send(command);

    ////    if (sucesso)
    ////        return NoContent();

    ////    return NotFound();
    ////}

    ////[HttpPatch("{vendaId}/itens/{itemId}")]
    ////public async Task<IActionResult> CancelarItem(Guid vendaId, Guid itemId)
    ////{
    ////    var command = new CancelarItemVendaCommand { VendaId = vendaId, ItemVendaId = itemId };
    ////    var sucesso = await _mediator.Send(command);

    ////    if (sucesso)
    ////        return NoContent();

    ////    return NotFound();
    ////}

    ////[HttpGet("{id}")]
    ////public async Task<ActionResult<Venda>> ObterVenda(Guid id)
    ////{
    ////    // Aqui você pode implementar um comando de consulta (Query), como no padrão CQRS
    ////    var venda = await _mediator.Send(new ObterVendaQuery { VendaId = id });
    ////    return venda != null ? Ok(venda) : NotFound();
    ////}
}
