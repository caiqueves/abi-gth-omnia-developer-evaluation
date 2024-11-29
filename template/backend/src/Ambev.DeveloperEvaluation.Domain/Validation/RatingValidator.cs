using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class RatingValidator : AbstractValidator<Rating>
{
    public RatingValidator()
    {
        RuleFor(ads => ads.Count).GreaterThan(0)
            .WithMessage("Count cannot be None");

        RuleFor(ads => ads.Rate).GreaterThan(0)
            .WithMessage("Rate cannot be None");

    }
}
