using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Repositories;
using UserManagement.Domain.Roles;
using UserManagement.Infrastructure.Common;

namespace UserManagement.Infrastructure.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(UserManagementDbContext context) : base(context)
        {
        }

        public Task<Role> GetByRoleNameAsync(string roleName, CancellationToken cancellationToken)
        {
            return _dbSet.SingleAsync(r => r.RoleName == roleName, cancellationToken);
        }
    }
}
