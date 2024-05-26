using UserManagement.Application.Users.Responses;

namespace UserManagement.Application.Services
{
    public interface IAdminService
    {
        Task<List<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<UserResponseModel> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken); 
        Task DeleteUserAsync(string userName, CancellationToken cancellationToken);
        Task SetAdminAsync(string userName, CancellationToken cancellationToken);
    }
}
