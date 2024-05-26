using UserManagement.Application.Common;

namespace UserManagement.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    }
}
