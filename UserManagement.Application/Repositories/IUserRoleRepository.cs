using UserManagement.Application.Common;
using UserManagement.Domain.UserRoles;

namespace UserManagement.Application.Repositories
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        Task<UserRole?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    }
}
