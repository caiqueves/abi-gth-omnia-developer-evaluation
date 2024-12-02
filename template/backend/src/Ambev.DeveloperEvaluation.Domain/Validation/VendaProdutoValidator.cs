using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class VendaProdutoValidator : AbstractValidator<VendaProduto>
{
    public VendaProdutoValidator()
    {
        RuleFor(ads => ads.VendaId).NotEmpty()
            .WithMessage("Venda Id cannot be None");

        RuleFor(ads => ads.ProdutoId).NotEmpty()
            .WithMessage("Produto Id cannot be None");

        RuleFor(ads => ads.Quantidade).NotEmpty()
            .WithMessage("Quantidade cannot be None");

        RuleFor(ads => ads.PrecoUnitario).NotEmpty()
            .WithMessage("Preco Unitario cannot be None");

        RuleFor(ads => ads.Desconto).NotEmpty()
            .WithMessage("Desconto cannot be None");

        RuleFor(ads => ads.ValorTotal).NotEmpty()
            .WithMessage("Valor Total cannot be None");
    }
}
