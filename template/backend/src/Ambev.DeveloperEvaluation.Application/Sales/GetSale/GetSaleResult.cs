using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    public Guid Id { get; set; }
    public Guid SaleNumber { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public DateTime SaleDate { get; set; }
    public bool IsCancelled { get; set; }
    public List<SaleItem>? SaleItems { get; set; }

}
