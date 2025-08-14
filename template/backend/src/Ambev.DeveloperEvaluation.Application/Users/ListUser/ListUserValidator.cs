using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

public class ListUserValidator : AbstractValidator<ListUserCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public ListUserValidator()
    {
        RuleFor(x => x.Page)
           .GreaterThan(0).WithMessage("Page must be greater than 0.");

        RuleFor(x => x.Size)
           .GreaterThan(0).WithMessage("Size must be greater than 0.");
    }
}
