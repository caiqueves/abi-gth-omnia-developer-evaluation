using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Vendas.ObterVenda;


public class ObterVendaValidator : AbstractValidator<ObterVendaCommand>
{
    public ObterVendaValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O ID da Venda não pode ser vazio.")
            .NotEqual(Guid.Empty).WithMessage("O ID da Venda não pode ser um GUID vazio.");



    }
}