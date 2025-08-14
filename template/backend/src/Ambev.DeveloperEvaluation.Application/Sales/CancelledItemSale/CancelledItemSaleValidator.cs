
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;


public class CancelledItemSaleValidator : AbstractValidator<UpdateSaleComand>
{
    //public CancelarItemVendaValidator()
    //{
    //    RuleFor(x => x.ClienteId)
    //        .NotEmpty().WithMessage("O ID do cliente não pode ser vazio.")
    //        .NotEqual(Guid.Empty).WithMessage("O ID do cliente não pode ser um GUID vazio.");


    //    //RuleFor(x => x.FilialId)
    //    //    .NotEmpty().WithMessage("O ID da filial não pode ser vazio.")
    //    //    .NotEqual(Guid.Empty).WithMessage("O ID da filial não pode ser um GUID vazio.");

    //    RuleFor(x => x.DataVenda)
    //        .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data da venda não pode ser no futuro.");


    //    RuleFor(x => x.ItensVenda)
    //        .NotEmpty().WithMessage("A venda deve conter pelo menos um item.");
    //}
}