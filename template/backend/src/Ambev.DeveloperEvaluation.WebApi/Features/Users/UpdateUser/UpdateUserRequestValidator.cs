using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;


public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public UpdateUserRequestValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.FirstName).NotEmpty().MinimumLength(10).MaximumLength(50);
        RuleFor(user => user.LastName).NotEmpty().MinimumLength(10).MaximumLength(50);
        RuleFor(user => user.City).NotEmpty();
        RuleFor(user => user.Street).NotEmpty();
        RuleFor(user => user.Number).NotEmpty();
        RuleFor(user => user.ZipCode).NotEmpty().MinimumLength(8).MaximumLength(8);
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        RuleFor(user => user.Role).NotEqual(UserRole.None);

    }
}
