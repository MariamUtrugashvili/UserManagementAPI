namespace UserManagement.Application.Users.Responses
{
    public class UserResponseModel
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
    }
}
