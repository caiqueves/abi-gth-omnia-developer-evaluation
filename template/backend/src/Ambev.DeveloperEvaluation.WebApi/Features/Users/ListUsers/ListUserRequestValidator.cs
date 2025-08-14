using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class ListUserRequestValidator : AbstractValidator<ListUserRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public ListUserRequestValidator()
    {
        RuleFor(x => x.Page)
              .NotEmpty()
              .WithMessage("User Page is required");

        RuleFor(x => x.Size)
             .NotEmpty()
             .WithMessage("User Size is required");


    }
}
