
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsCategory;

public class ListProductCategoryValidator : AbstractValidator<ListProductCategoryCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public ListProductCategoryValidator()
    {
        RuleFor(x => x.Page)
           .GreaterThan(0).WithMessage("Page must be greater than 0.");

        RuleFor(x => x.Size)
           .GreaterThan(0).WithMessage("Size must be greater than 0.");

        RuleFor(x => x.Category)
           .NotEmpty()
           .WithMessage("Category not permited is null");
    }
}
