using Events.API.Infrastructure.ExceptionHandler;
using Newtonsoft.Json;

namespace UserManagementAPI.Infrastructure.Middleware
{
    public class GlobalExeptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExeptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ExceptionHandlerasync(context, ex);
            }
        }
        private async Task ExceptionHandlerasync(HttpContext context, Exception exception)
        {
            var error = new ErrorsDetails(context, exception);
            var json = JsonConvert.SerializeObject(error);
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error!.Status!.Value;
            await context.Response.WriteAsync(json);
        }
    }
}
