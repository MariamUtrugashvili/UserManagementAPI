namespace UserManagement.Application.Auth.Responses
{
    public class SignInResponse
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string RoleName { get; set; }
    }
}
