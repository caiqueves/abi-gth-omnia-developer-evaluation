using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class GeolocationValidator : AbstractValidator<Geolocation>
{
    public GeolocationValidator()
    {
        RuleFor(ads => ads.Lat).NotEmpty()
            .WithMessage("Lat cannot be None");

        RuleFor(ads => ads.Long).NotEmpty()
            .WithMessage("Long cannot be None");
    }
}
