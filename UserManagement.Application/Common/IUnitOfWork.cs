using UserManagement.Application.Repositories;

namespace UserManagement.Application.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }

        Task<bool> SaveAsync();
    }
}
