using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class ListProductRequestValidator : AbstractValidator<ListProductRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public ListProductRequestValidator()
    {
        RuleFor(x => x.Page)
              .NotEmpty()
              .WithMessage("User Page is required");

        RuleFor(x => x.Size)
             .NotEmpty()
             .WithMessage("User Size is required");


    }
}
