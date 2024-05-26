using Swashbuckle.AspNetCore.Filters;
using UserManagement.Application.Auth.Requests;

namespace UserManagementAPI.Infrastructure.Examples.User
{
    public class UserLogInExamples : IMultipleExamplesProvider<SignInRequest>
    {
        public IEnumerable<SwaggerExample<SignInRequest>> GetExamples()
        {
            yield return SwaggerExample.Create("Example 1", new SignInRequest
            {
                Email = "GiorgiBeridze@gmail.com",
                Password = "GiorgiBeridze1!"
            });

            yield return SwaggerExample.Create("Example 2", new SignInRequest
            {
                Email = "NiniBeridze@gmail.com",
                Password = "NiniBeridze01!"
            });
        }
    }
}
