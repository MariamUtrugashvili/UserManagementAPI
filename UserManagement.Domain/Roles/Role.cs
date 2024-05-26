using UserManagement.Domain.UserRoles;

namespace UserManagement.Domain.Roles
{
    public class Role
    {
        public Guid Id { get; set; }
        public required string RoleName { get; set; } = Enums.UserRoles.User.ToString();

        // Navigation property
        public ICollection<UserRole>? UserRoles { get; set; } 
    }
}
