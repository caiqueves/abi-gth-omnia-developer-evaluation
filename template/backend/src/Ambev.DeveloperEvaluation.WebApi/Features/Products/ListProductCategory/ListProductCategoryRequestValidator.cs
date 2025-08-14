using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategory;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class ListProductCategoryRequestValidator : AbstractValidator<ListProductCategoryRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public ListProductCategoryRequestValidator()
    {
        RuleFor(x => x.Page)
              .NotEmpty()
              .WithMessage("User Page is required");

        RuleFor(x => x.Size)
             .NotEmpty()
             .WithMessage("User Size is required");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required");


    }
}
