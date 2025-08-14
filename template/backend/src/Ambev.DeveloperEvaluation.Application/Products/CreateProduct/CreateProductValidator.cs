using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductComandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductComandValidator()
    {
        RuleFor(prd => prd.Title).NotEmpty();
        RuleFor(user => user.Price).NotEmpty();
        RuleFor(user => user.Amount).NotEmpty();
        RuleFor(user => user.Description).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(user => user.Category).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(user => user.Image).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(user => user.Rate).NotEmpty();
        RuleFor(user => user.Count).NotEmpty();
    }
}