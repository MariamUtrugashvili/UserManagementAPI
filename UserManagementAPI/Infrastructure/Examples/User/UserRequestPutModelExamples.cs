using Swashbuckle.AspNetCore.Filters;
using UserManagement.Application.Users.Requests;

namespace UserManagementAPI.Infrastructure.Examples.User
{
    public class UserRequestPutModelExamples : IMultipleExamplesProvider<UserRequestPutModel>
    {
        public IEnumerable<SwaggerExample<UserRequestPutModel>> GetExamples()
        {
            yield return SwaggerExample.Create("Example 1", new UserRequestPutModel
            {
                Email = "GiorgiBeridze@gmail.com",
                UserName = "Giorgi",
                Password = "GiorgiBeridze1!"
            });

            yield return SwaggerExample.Create("Example 2", new UserRequestPutModel
            {
                Email = "NiniBeridze@gmail.com",
                UserName = "Nini",
                Password = "NiniBeridze01!"
            });
        }
    }
}
