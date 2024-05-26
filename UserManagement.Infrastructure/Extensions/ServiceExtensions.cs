using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.Common;
using UserManagement.Application.Repositories;
using UserManagement.Application.Services;
using UserManagement.Infrastructure.Common;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Infrastructure.Services;

namespace UserManagement.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddUnitOfWork(services);
            AddRepositories(services);
            AddServices(services);
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();

            return services;
        }
    }
}
