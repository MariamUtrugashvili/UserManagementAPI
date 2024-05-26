using UserManagement.Application.Common;
using UserManagement.Application.Repositories;
using UserManagement.Infrastructure.Repositories;


namespace UserManagement.Infrastructure.Common
{
    public class UnitOfWork(UserManagementDbContext dbContext) : IUnitOfWork
    {
        private readonly UserManagementDbContext _dbContext = dbContext;
        private bool _disposed;

        public IUserRepository UserRepository => new UserRepository(_dbContext);
        public IRoleRepository RoleRepository => new RoleRepository(_dbContext);
        public IUserRoleRepository UserRoleRepository => new UserRoleRepository(_dbContext);

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
