using FluentValidation;
using UserManagement.Application.Auth.Requests;
using UserManagementAPI.Infrastructure.Extensions.Validation;

namespace UserManagementAPI.Infrastructure.Validators.User
{
    public class UserCreateValidator : AbstractValidator<SignInRequest>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.Password.Length)
                        .NotEmpty()
                        .WithMessage("Password should not be empty.")
                        .ExclusiveBetween(8, 40)
                        .WithMessage("Password is invalid (Valid: 8-40 characters)");

            RuleFor(x => x.Email).Email();

        }
    }
}
