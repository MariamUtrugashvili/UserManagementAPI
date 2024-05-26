using Swashbuckle.AspNetCore.Filters;
using UserManagement.Application.Auth.Requests;

namespace UserManagementAPI.Infrastructure.Examples.User
{
    public class UserRegistrationExamples : IMultipleExamplesProvider<SignUpRequest>
    {
        public IEnumerable<SwaggerExample<SignUpRequest>> GetExamples()
        {
            yield return SwaggerExample.Create("Example 1", new SignUpRequest
            {
                Email = "GiorgiBeridze@gmail.com",
                UserName = "Giorgi",
                Password = "GiorgiBeridze1!"
            });

            yield return SwaggerExample.Create("Example 2", new SignUpRequest
            {
                Email = "NiniBeridze@gmail.com",
                UserName="Nini",
                Password = "NiniBeridze01!"
            });
        }
    }
}
