using UserManagement.Application.Common;
using UserManagement.Domain.Roles;

namespace UserManagement.Application.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetByRoleNameAsync(string roleName, CancellationToken cancellationToken);
    }
}
