using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public record CreateSaleResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItem>? Product { get; set; }
}
