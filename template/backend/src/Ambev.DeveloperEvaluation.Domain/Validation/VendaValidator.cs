using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class VendaValidator : AbstractValidator<Venda>
{
    public VendaValidator()
    {
        RuleFor(ads => ads.DataVenda).NotEmpty()
            .WithMessage("Data Venda cannot be None");

        RuleFor(ads => ads.ValorTotal).NotEmpty()
            .WithMessage("Valor Total cannot be None");

        RuleFor(ads => ads.ValorTotal).NotEmpty()
            .WithMessage("Valor Total cannot be None");

        RuleFor(ads => ads.Cancelado).NotEmpty()
            .WithMessage("Cancelado Total cannot be None");

        RuleFor(ads => ads.ClienteId).NotEmpty()
            .WithMessage("Cliente Id cannot be None");

        //RuleFor(ads => ads.FilialId).NotEmpty()
        //    .WithMessage("Filial Id cannot be None");


    }
}
