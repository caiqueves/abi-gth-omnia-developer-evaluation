using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;


public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(prd => prd.Id).NotEmpty();
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
