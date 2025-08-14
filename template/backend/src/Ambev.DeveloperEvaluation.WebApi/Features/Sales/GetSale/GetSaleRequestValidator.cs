
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    public GetSaleRequestValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("The Sale ID cannot be an empty GUID.")
        .NotEqual(Guid.Empty).WithMessage("The sale ID cannot be an empty GUID.");
    }
}
