using Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CriarVenda;


public class CriarVendaComandValidator : AbstractValidator<CriarVendaCommand>
{
    public CriarVendaComandValidator()
    {
        RuleFor(x => x.ClienteId)
            .NotEmpty().WithMessage("O ID do cliente não pode ser vazio.")
            .NotEqual(Guid.Empty).WithMessage("O ID do cliente não pode ser um GUID vazio.");


        //RuleFor(x => x.FilialId)
        //    .NotEmpty().WithMessage("O ID da filial não pode ser vazio.")
        //    .NotEqual(Guid.Empty).WithMessage("O ID da filial não pode ser um GUID vazio.");

        RuleFor(x => x.DataVenda)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data da venda não pode ser no futuro.");


        RuleFor(x => x.ItensVenda)
            .NotEmpty().WithMessage("A venda deve conter pelo menos um item.");

        RuleForEach(x => x.ItensVenda)
            .ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId)
                    .NotEmpty().WithMessage("O ID do produto não pode ser vazio.");

                item.RuleFor(i => i.Quantidade)
                    .GreaterThan(0).WithMessage("A quantidade do produto deve ser maior que 0.");
            });
    }
}