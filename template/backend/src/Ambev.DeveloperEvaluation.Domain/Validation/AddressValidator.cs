using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(ads => ads.City).NotEmpty()
            .WithMessage("City cannot be None");

        RuleFor(ads => ads.Street).NotEmpty()
            .WithMessage("Street cannot be None");

        RuleFor(user => user.Number).NotEmpty().GreaterThan(0)
            .WithMessage("Number cannot be None")
            .WithMessage("Number cannot be 0");

        RuleFor(ads => ads.Zipcode).NotEmpty()
            .MinimumLength(8)
            .MaximumLength(8)
           .WithMessage("Zipcode cannot be None")
           .WithMessage("ZipCode must be greater than 0 and less than 9");

        RuleFor(user => user.GeolocationId).NotEmpty()
        .WithMessage("GeolocationId cannot be None");


    }
}
