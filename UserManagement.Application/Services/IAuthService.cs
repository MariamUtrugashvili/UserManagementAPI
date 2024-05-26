using UserManagement.Application.Auth.Requests;
using UserManagement.Application.Auth.Responses;

namespace UserManagement.Application.Services
{
    public interface IAuthService
    {
        Task<SignInResponse> AuthenticateAsync(SignInRequest user, CancellationToken cancellationToken);
        Task RegisterAsync(SignUpRequest user, CancellationToken cancellationToken);
    }
}
