using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
    {
        public Guid CustomerId { get; set; }

        public Guid BranchId { get; set; }
    
        public DateTime SaleDate { get; set; } 

        public List<SaleItem>? SaleItems { get; set; }   
    }
