using UserManagementAPI.Infrastructure.Middleware;

namespace UserManagementAPI.Infrastructure.Extensions.MiddleWare
{
    public static class GlobalExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExeptionsMiddleware>();
        }
    }
}
