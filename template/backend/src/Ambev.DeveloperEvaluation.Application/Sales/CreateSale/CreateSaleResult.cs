using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResult
{
    public Guid Id { get; set; } 
    public Guid CustomerId { get; set; }

    public DateTime SaleDate { get; set; }

    public List<SaleItem>? Product { get; set; }

}
