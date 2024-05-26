using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Repositories;
using UserManagement.Domain.UserRoles;
using UserManagement.Infrastructure.Common;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(UserManagementDbContext context) : base(context)
        {
        }

        public Task<UserRole?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
        }
    }
}
