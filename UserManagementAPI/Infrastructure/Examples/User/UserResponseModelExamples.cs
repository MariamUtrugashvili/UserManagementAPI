using Swashbuckle.AspNetCore.Filters;
using UserManagement.Application.Users.Responses;

namespace UserManagementAPI.Infrastructure.Examples.User
{
    public class UserResponseModelExamples : IMultipleExamplesProvider<UserResponseModel>
    {
        public IEnumerable<SwaggerExample<UserResponseModel>> GetExamples()
        {
            yield return SwaggerExample.Create("Example 1", new UserResponseModel
            {
                Id = Guid.NewGuid(),
                Email = "GiorgiBeridze@gmail.com",
                UserName = "Giorgi",
            });

            yield return SwaggerExample.Create("Example 2", new UserResponseModel
            {
                Id = Guid.NewGuid(),
                Email = "NiniBeridze@gmail.com",
                UserName = "Nini",
            });
        }
    }
}
