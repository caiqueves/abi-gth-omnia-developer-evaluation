using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;


public class CancelSaleValidator : AbstractValidator<CancelSaleCommand>
{
    public CancelSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The Sale ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("The Sale ID cannot be an empty GUID.");


       
    }
}