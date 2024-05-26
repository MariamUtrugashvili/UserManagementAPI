using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Services;
using UserManagement.Application.Users.Requests;
using UserManagement.Application.Users.Responses;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        /// <summary>
        /// Get All User
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>List Of Users</returns>
        [HttpGet("AllUsers")]
        public async Task<ActionResult<List<UserResponseModel>>> GetAllUsers(CancellationToken cancellationToken)
        {
            return Ok(await _adminService.GetAllUsersAsync(cancellationToken));
        }

        /// <summary>
        /// Get User Information by Username
        /// </summary>
        /// <param name="userName">UserName To Get Information By</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>User Information</returns>
        [HttpGet("GetUserInformation/{userName}")]
        public async Task<ActionResult<UserProfileResponseModel>> GetUserInfo(string userName, CancellationToken cancellationToken)
        {
            return Ok(await _adminService.GetUserByUserNameAsync(userName, cancellationToken));
        }

        /// <summary>
        /// Update User Profile by Id
        /// </summary>
        /// <param name="user">Update Model Parameters</param>
        /// <param name="id">Update Model Id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Status of operation</returns>
        [HttpPut("UpdateProfile/{id}")]
        public async Task<ActionResult> UpdateProfile(UserRequestPutModel user, Guid id, CancellationToken cancellationToken)
        { 
            await _userService.UpdateProfileAsync(user, id, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Delete User 
        /// </summary>
        /// <param name="userName">UserName To Delete User Profile</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Status of operation</returns>
        [HttpDelete("DeleteProfile/{userName}")]
        public async Task<ActionResult> DeleteProfile(string userName, CancellationToken cancellationToken)
        {
            await _adminService.DeleteUserAsync(userName, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Set User To Admin
        /// </summary>
        /// <param name="userName">UserName To Set New Admin</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Status of operation</returns>
        [HttpPut("SetAdmin/{userName}")]
        public async Task<ActionResult> SetAdmin(string userName,CancellationToken cancellationToken)
        {
            await _adminService.SetAdminAsync(userName,cancellationToken);
            return NoContent();
        }
    }
}
