using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;


public class GetSaleValidator : AbstractValidator<GetSaleComand>
{
    public GetSaleValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("The Sale ID cannot be an empty GUID.")
        .NotEqual(Guid.Empty).WithMessage("The sale ID cannot be an empty GUID.");
    }
}