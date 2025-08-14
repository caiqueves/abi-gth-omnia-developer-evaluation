using Ambev.DeveloperEvaluation.Application.Products.ListProducts;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

public class ListProductValidator : AbstractValidator<ListProductCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public ListProductValidator()
    {
        RuleFor(x => x.Page)
           .GreaterThan(0).WithMessage("Page must be greater than 0.");

        RuleFor(x => x.Size)
           .GreaterThan(0).WithMessage("Size must be greater than 0.");
    }
}
