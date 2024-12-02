using Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.CancelarVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.ObterVenda;
using Ambev.DeveloperEvaluation.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.AtualizarVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CriarVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
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
            Data = _mapper.Map<CriarVendaResponse>(response)
        });

    }

    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetVendaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ObterVenda(Guid id, CancellationToken cancellationToken)
    {
        var request = new GetVendaRequest(id);
        var validator = new GetVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<ObterVendaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<GetVendaResponse>(response));
    }

    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<AtualizarVendaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtualizarVenda(Guid id, [FromBody] AtualizarVendaRequest request, CancellationToken cancellationToken)
    {
        var validator = new AtualizarVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<AtualizarVendaComand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<AtualizarVendaResponse>(response));
    }

    [Authorize]
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<CancelarVendaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CancelarVenda(Guid id, CancellationToken cancellationToken)
    {
        var request = new CancelarVendaRequest(id);
        var validator = new CancelarVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CancelarVendaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<CancelarVendaResponse>(response));
    }

    ////[HttpPatch("{vendaId}/itens/{itemId}")]
    ////public async Task<IActionResult> CancelarItem(Guid vendaId, Guid itemId)
    ////{
    ////    var command = new CancelarItemVendaCommand { VendaId = vendaId, ItemVendaId = itemId };
    ////    var sucesso = await _mediator.Send(command);

    ////    if (sucesso)
    ////        return NoContent();

    ////    return NotFound();
    ////}

  
}
