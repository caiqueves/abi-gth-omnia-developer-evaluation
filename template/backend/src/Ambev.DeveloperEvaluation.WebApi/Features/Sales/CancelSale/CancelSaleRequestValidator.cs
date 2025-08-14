
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
{
    public CancelSaleRequestValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("O ID da venda não pode ser vazio.")
        .NotEqual(Guid.Empty).WithMessage("O ID da venda não pode ser um GUID vazio.");



    }
}
