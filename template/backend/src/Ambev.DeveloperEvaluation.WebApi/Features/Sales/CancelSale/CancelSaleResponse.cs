
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

public record CancelSaleResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItem>? Product { get; set; }

    public string Message { get; set; } = string.Empty;
}

