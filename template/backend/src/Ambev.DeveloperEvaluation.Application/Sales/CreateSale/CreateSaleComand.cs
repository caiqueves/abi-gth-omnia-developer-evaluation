using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleComand: IRequest<CreateSaleResult>
{   
    public Guid CustomerId { get; set; }  
    public Guid BranchId { get; set; }   
    public DateTime SaleDate { get; set; } 

    public List<SaleItem>? SaleItems { get; set; }

    // Construtor
    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleComandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
