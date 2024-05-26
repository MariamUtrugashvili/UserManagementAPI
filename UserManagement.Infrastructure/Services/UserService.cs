using UserManagement.Application.Users.Responses;
using UserManagement.Application.Common;
using Mapster;
using UserManagement.Application.Users.Requests;
using UserManagement.Application.Services;
using UserManagement.Application.Exceptions;

namespace UserManagement.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region ctor
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<UserProfileResponseModel> GetUserInfoAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetAsync(key: id, token: cancellationToken) ?? throw new UserNotFoundException("User Not Found");

            return result.Adapt<UserProfileResponseModel>();
        }

        public async Task UpdateProfileAsync(UserRequestPutModel user, Guid id, CancellationToken cancellationToken)
        {

            if (!await _unitOfWork.UserRepository.AnyAsync(u => u.Id == id, cancellationToken))
                throw new UserNotFoundException("User with this Id wasn't found");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var entity = user.Adapt<User>();
            entity.Id = id;
            entity.Password = hashedPassword;

            _unitOfWork.UserRepository.Update(entity, cancellationToken);
            
            await _unitOfWork.SaveAsync();        
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(key: id, token: cancellationToken) 
                ?? throw new UserNotFoundException("User with this Id wasn't found");

            user.Status = Domain.Enums.UserStatus.Deleted;

            _unitOfWork.UserRepository.Update(user, cancellationToken);

            await _unitOfWork.SaveAsync();
        }

    }
}
