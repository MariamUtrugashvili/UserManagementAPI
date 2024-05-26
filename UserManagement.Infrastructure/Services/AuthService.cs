using Mapster;
using UserManagement.Application.Auth.Requests;
using UserManagement.Application.Auth.Responses;
using UserManagement.Application.Common;
using UserManagement.Application.Exceptions;
using UserManagement.Application.Helpers;
using UserManagement.Application.Services;
using UserManagement.Domain.Enums;
using UserManagement.Domain.UserRoles;

namespace UserManagement.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<SignInResponse> AuthenticateAsync(SignInRequest user, CancellationToken cancellationToken)
        {
            var storedUser = await _unitOfWork.UserRepository.GetPropertyAsync(
                predicate: x => string.Equals(x.Email, user.Email), 
                selector:  user => user, 
                token:  cancellationToken);

            if (storedUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, storedUser.Password))
                throw new InvalidAccount("Invalid email or password");

            var userRoleId = await _unitOfWork.UserRoleRepository.GetPropertyAsync(x => x.UserId == storedUser.Id, userRole => userRole.RoleId, cancellationToken);

            var userRoleName = await _unitOfWork.RoleRepository.GetPropertyAsync(x => x.Id == userRoleId, role => role.RoleName, cancellationToken);

            return new SignInResponse { Id = storedUser.Id, UserName = storedUser.UserName, RoleName = userRoleName};
        }

        public async Task RegisterAsync(SignUpRequest user, CancellationToken cancellationToken)
        {
            await UserValidationHelper.ValidateUserAsync(_unitOfWork.UserRepository, user.UserName, user.Email, cancellationToken);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
  
            var entity = user.Adapt<User>();
            entity.Password = hashedPassword;

            await _unitOfWork.UserRepository.AddAsync(entity, cancellationToken);

            var role = await _unitOfWork.RoleRepository.GetByRoleNameAsync(UserRoles.User.ToString(), cancellationToken);

            var userRole = new UserRole
            {
                UserId = entity.Id,
                RoleId = role.Id,
            };

            await _unitOfWork.UserRoleRepository.AddAsync(userRole, cancellationToken);

            await _unitOfWork.SaveAsync();
        }
    }

}
