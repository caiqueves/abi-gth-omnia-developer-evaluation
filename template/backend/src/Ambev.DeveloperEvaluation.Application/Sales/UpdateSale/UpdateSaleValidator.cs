
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;


public class UpdateSaleValidator : AbstractValidator<UpdateSaleComand>
{
    public UpdateSaleValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Client ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("The client ID cannot be an empty GUID.");

        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("The Branch ID cannot be an empty GUID.");

        RuleFor(x => x.SaleDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The sale date cannot be in the future.")
            .NotNull().WithMessage("SaleDate cannot be empty.");

        RuleFor(x => x.SaleItems)
            .NotEmpty().WithMessage("The sale must contain at least one item.");

        RuleForEach(x => x.SaleItems)
            .ChildRules(item =>
            {
                item.RuleFor(i => i.Id)
                    .NotEmpty().WithMessage("Product ID cannot be empty.");

                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Product quantity must be greater than 0.");
            });
    }
}