
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.DeleteSale
{
    public class CancelarVendaRequestValidator : AbstractValidator<CancelarVendaRequest>
    {
        public CancelarVendaRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O ID da venda não pode ser vazio.")
            .NotEqual(Guid.Empty).WithMessage("O ID da venda não pode ser um GUID vazio.");


           
        }
    }
}
