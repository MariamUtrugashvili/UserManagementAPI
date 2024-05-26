using UserManagement.Application.Users.Requests;
using UserManagement.Application.Users.Responses;

namespace UserManagement.Application.Services
{
    public interface IUserService
    {
        Task<UserProfileResponseModel> GetUserInfoAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateProfileAsync(UserRequestPutModel user, Guid id, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken); 
    }
}
