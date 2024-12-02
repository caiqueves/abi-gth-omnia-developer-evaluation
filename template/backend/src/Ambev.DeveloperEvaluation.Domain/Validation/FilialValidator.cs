using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class FilialValidator : AbstractValidator<Filial>
{
    public FilialValidator()
    {
        RuleFor(ads => ads.Nome).NotEmpty()
            .WithMessage("Nome cannot be None");

        RuleFor(ads => ads.Endereco).NotEmpty()
            .WithMessage("Endereco cannot be None");
    }
}
