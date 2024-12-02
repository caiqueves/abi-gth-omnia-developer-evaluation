
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;

public class GetVendaRequestValidator : AbstractValidator<GetVendaRequest>
{
    public GetVendaRequestValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("O ID da venda não pode ser vazio.")
        .NotEqual(Guid.Empty).WithMessage("O ID da venda não pode ser um GUID vazio.");


       
    }
}
