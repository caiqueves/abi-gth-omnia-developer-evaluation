using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;


public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(prd => prd.Id).NotEmpty();
        RuleFor(prd => prd.Title).NotEmpty();
        RuleFor(prd => prd.Price).NotEmpty();
        RuleFor(prd => prd.Amount).NotEmpty();
        RuleFor(prd => prd.Description).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(prd => prd.Category).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(prd => prd.Image).NotEmpty().MinimumLength(10).MaximumLength(100);
        RuleFor(prd => prd.Rate).NotEmpty();
        RuleFor(prd => prd.Count).NotEmpty();
    }
}