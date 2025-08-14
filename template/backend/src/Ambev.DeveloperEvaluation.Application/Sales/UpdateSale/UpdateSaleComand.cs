using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleComand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }
    public Guid SaleNumber { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public DateTime SaleDate { get; set; }
    public bool IsCancelled { get; set; }
    public List<SaleItem>? SaleItems { get; set; }

    public UpdateSaleComand()
    {
    }
    public UpdateSaleComand(Guid id, Guid salesNumber, Guid customerId, Guid branchId, DateTime saleDate, bool isCancelled, List<SaleItem>? saleItems)
    {
        Id = id;
        SaleNumber = salesNumber;
        CustomerId = customerId;
        BranchId = branchId;
        SaleDate = saleDate;
        IsCancelled = isCancelled;
        SaleItems = saleItems;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
