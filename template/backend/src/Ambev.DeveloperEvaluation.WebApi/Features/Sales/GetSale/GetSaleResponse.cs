
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public record GetSaleResponse
    {
        public Guid Id { get; set; }
        public Guid SaleNumber { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime SaleDate { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItem>? SaleItems { get; set; }
    }
}
