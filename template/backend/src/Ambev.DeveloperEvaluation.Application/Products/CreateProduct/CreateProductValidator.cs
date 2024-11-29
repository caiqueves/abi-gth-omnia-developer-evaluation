using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateUserCommand that defines validation rules for user creation command.
/// </summary>
public class CreateProductComandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductComandValidator()
    {
        RuleFor(prd => prd.Title).NotEmpty();
        RuleFor(user => user.Price).NotEmpty();
        RuleFor(user => user.Description).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(user => user.Category).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(user => user.Image).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(user => user.Rate).NotEmpty();
        RuleFor(user => user.Count).NotEmpty();
    }
}