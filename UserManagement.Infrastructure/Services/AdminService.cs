using Mapster;
using UserManagement.Application.Common;
using UserManagement.Application.Exceptions;
using UserManagement.Application.Services;
using UserManagement.Application.Users.Responses;
using UserManagement.Domain.Enums;

namespace UserManagement.Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region ctor
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<List<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetAllAsync(cancellationToken) ?? throw new UserNotFoundException("Not Found");
            
            return result.Adapt<List<UserResponseModel>>();
        }

        public async Task<UserResponseModel> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetByUsernameAsync(userName, cancellationToken) ?? throw new UserNotFoundException("Not Found");

            return result.Adapt<UserResponseModel>();
        }
        public async Task DeleteUserAsync(string userName, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetPropertyAsync(
                predicate: x => string.Equals(x.UserName, userName),
                selector: user => user,
                token: cancellationToken) ?? throw new UserNotFoundException("Not Found");

            user.Status = UserStatus.Deleted;

            _unitOfWork.UserRepository.Update(user, cancellationToken);

            await _unitOfWork.SaveAsync();
        }

        public async Task SetAdminAsync(string userName, CancellationToken cancellationToken)
        {
            var userId = await _unitOfWork.UserRepository.GetPropertyAsync(x => x.UserName == userName, user => user.Id, cancellationToken);

            var roleId = await _unitOfWork.RoleRepository.GetPropertyAsync(x => x.RoleName == UserRoles.Admin.ToString(), role => role.Id, cancellationToken);

            var userRoleResult = await _unitOfWork.UserRoleRepository.GetByUserIdAsync(userId, cancellationToken) ?? throw new UserNotFoundException("Not Found");

            userRoleResult.Id = userRoleResult.Id;
            userRoleResult.UserId = userId;
            userRoleResult.RoleId = roleId;

             _unitOfWork.UserRoleRepository.Update(userRoleResult, cancellationToken);

            await _unitOfWork.SaveAsync();
        }
    }
}
