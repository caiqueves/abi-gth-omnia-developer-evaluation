
using Ambev.DeveloperEvaluation.Application.Vendas.CancelarVenda;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CancelarVenda;


public class CancelarVendaValidator : AbstractValidator<CancelarVendaCommand>
{
    public CancelarVendaValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O ID da Venda não pode ser vazio.")
            .NotEqual(Guid.Empty).WithMessage("O ID da Venda não pode ser um GUID vazio.");


       
    }
}