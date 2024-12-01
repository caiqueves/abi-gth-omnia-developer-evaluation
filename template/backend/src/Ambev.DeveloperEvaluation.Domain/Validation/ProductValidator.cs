using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(ads => ads.Title).NotEmpty()
            .WithMessage("Title cannot be None");

        RuleFor(ads => ads.Price).NotEmpty()
            .WithMessage("Price cannot be None");

        RuleFor(user => user.Description).NotEmpty()
            .MinimumLength(15)
            .MaximumLength(100)
            .WithMessage("Description cannot be None")
            .WithMessage("Description cannot be 0");

        RuleFor(ads => ads.Category).NotEmpty()
            .MinimumLength(10)
            .MaximumLength(10)
           .WithMessage("Description must be greater than 0 and less than 10");

        RuleFor(ads => ads.Image).NotEmpty()
            .MinimumLength(50)
            .MaximumLength(100)
           .WithMessage("Image must be greater than 0 and less than 100");

        RuleFor(ads => ads.RatingId).NotEmpty()
           .WithMessage("RatingId cannot be None");

        RuleFor(ads => ads.Amount).NotEmpty()
           .WithMessage("Amount cannot be None");




    }
}
