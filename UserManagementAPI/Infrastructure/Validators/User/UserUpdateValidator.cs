using FluentValidation;
using UserManagement.Application.Users.Requests;
using UserManagementAPI.Infrastructure.Extensions.Validation;

namespace UserManagementAPI.Infrastructure.Validators.User
{
    public class UserUpdateValidator : AbstractValidator<UserRequestPutModel>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.Password.Length)
                        .NotEmpty()
                        .WithMessage("Password should not be empty.")
                        .ExclusiveBetween(6, 40)
                        .WithMessage("Password is invalid (Valid: 6-40 characters)");

            RuleFor(x => x.UserName.Length)
                         .NotEmpty()
                         .WithMessage("UserName should not be empty.")
                         .ExclusiveBetween(6, 60)
                         .WithMessage("UserName is invalid (Valid: 6-60 characters)");

            RuleFor(x => x.Email).Email();

        }
    }

}
