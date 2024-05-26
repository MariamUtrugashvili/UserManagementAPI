using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Repositories;
using UserManagement.Infrastructure.Common;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserManagementDbContext context) : base(context) { }

        public Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return _dbSet.SingleAsync(r => r.UserName == username, cancellationToken);
        }
    }
}
