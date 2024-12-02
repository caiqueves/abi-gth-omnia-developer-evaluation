using Ambev.DeveloperEvaluation.Domain.Dto;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;

public class GetVendaRequest
{
    public Guid Id { get; set; }

    public GetVendaRequest(Guid id)
    {
        Id  = id;
    }
}
