using UserManagement.Application.Exceptions;
using UserManagement.Application.Repositories;

namespace UserManagement.Application.Helpers
{
    public static class UserValidationHelper
    {
        public static async Task ValidateUserAsync(IUserRepository userRepository, string username, string email, CancellationToken cancellationToken)
        {
            if (await userRepository.AnyAsync(u => u.UserName == username, cancellationToken))
                throw new AlreadyExistsException("Username already in use");

            if (await userRepository.AnyAsync(u => u.Email == email, cancellationToken))
                throw new AlreadyExistsException("Email already in use");
        }
    }
}
