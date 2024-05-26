using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UserManagement.Application.Auth.Requests;
using UserManagement.Application.Authentication;
using UserManagement.Application.Services;
using UserManagementAPI.Infrastructure.Authentication;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IOptions<JWTConfiguration> _options;
    
        public AuthController(IAuthService authService, IOptions<JWTConfiguration> options)
        {
            _authService = authService;
            _options = options;
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="user">Sign Up Parameters </param>
        /// <param name="cancellation">Cancellation Token</param>
        /// <returns>Status of operation</returns>
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] SignUpRequest user, CancellationToken cancellation)
        {
            await _authService.RegisterAsync(user, cancellation);

            return NoContent();
        }

        /// <summary>
        /// Log In
        /// </summary>
        /// <param name="request">Sign In Parameters</param>
        /// <param name="cancellation"> Cancellation Token</param>
        /// <returns>JWT of logged in User</returns>
        [Route("LogIn")]
        [HttpPost]
        public async Task<string> LogIn(SignInRequest request, CancellationToken cancellation)
        {
            var result = await _authService.AuthenticateAsync(request, cancellation);

            return JWTHelper.GenerateSecurityToken(result.UserName, result.Id, result.RoleName, _options);
        }
    }
}

