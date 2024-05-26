namespace UserManagement.Application.Users.Requests
{
    public class UserRequestPutModel
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
