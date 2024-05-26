using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserManagement.Application.Exceptions;

namespace Events.API.Infrastructure.ExceptionHandler
{
    public class ErrorsDetails : ProblemDetails
    {
        private const string UnexpectedErrorCode = "Unexpected error";
        private HttpContext httpContext;
        private Exception _exception;
        public LogLevel LogLevel { get; set; }
        public string Code { get; set; }
        public string? TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                {
                    return (string)traceId!;
                }

                return null;
            }

            set => Extensions["TraceId"] = value;
        }

        public ErrorsDetails(HttpContext context, Exception exception)
        {
            httpContext = context;
            _exception = exception;

            TraceId = httpContext.TraceIdentifier;
            Code = UnexpectedErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            LogLevel = LogLevel.Error;
            TraceId = context.TraceIdentifier;
            Instance = context.Request.Path;
            Title = exception.Message;

            HandleExceptions((dynamic)exception);
        }

        #region Exceptions
        private void HandleExceptions(AlreadyExistsException exception)
        {
            Code = exception.Message;
            Status = (int)HttpStatusCode.Conflict;
            LogLevel = LogLevel.Information;
            Title = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
        }

        private void HandleExceptions(UserNotFoundException exception)
        {
            Code = exception.Message;
            Status = (int)HttpStatusCode.NotFound;
            LogLevel = LogLevel.Information;
            Title = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        }


        private void HandleExceptions(InvalidAccount exception)
        {
            Code = exception.Message;
            Status = (int)HttpStatusCode.Conflict;
            LogLevel = LogLevel.Information;
            Title = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3.";
        }
        private void HandleExceptions(Exception exception) { }
        #endregion
    }
}
