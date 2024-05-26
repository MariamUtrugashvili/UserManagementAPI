using UserManagement.Infrastructure.Extensions;

namespace UserManagementAPI.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure();

            return builder;
        }
    }
}