using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Services;
using UserManagement.Application.Users.Requests;
using UserManagement.Application.Users.Responses;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Guid _userId;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;

            var userIdClaim = httpContextAccessor.HttpContext!.User.FindFirst("Id")!.Value;

            _userId = new Guid(userIdClaim);
        }

        /// <summary>
        /// Get My Profile Information
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>User Information</returns>
        [HttpGet("GetProfileInformation")]
        public async Task<ActionResult<UserProfileResponseModel>> GetProfileInfo(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetUserInfoAsync(_userId, cancellationToken));
        }

        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="user">Update Profile Parameters </param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Status of operation</returns>
        [HttpPut("UpdateProfile")]
        public async Task<ActionResult> UpdateProfile(UserRequestPutModel user, CancellationToken cancellationToken)
        {
            await _userService.UpdateProfileAsync(user, _userId, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Delete Profile
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Status of operation</returns>
        [HttpDelete("DeleteProfile")]
        public async Task<ActionResult> DeleteProfile(CancellationToken cancellationToken)
        {
            await _userService.DeleteAsync(_userId, cancellationToken);

            return NoContent();
        }
    }
}
