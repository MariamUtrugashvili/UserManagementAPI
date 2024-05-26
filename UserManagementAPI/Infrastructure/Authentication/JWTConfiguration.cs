namespace UserManagementAPI.Infrastructure.Authentication
{
    public class JWTConfiguration
    {
        public required string Secret { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
