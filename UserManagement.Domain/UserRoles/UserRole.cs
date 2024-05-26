using UserManagement.Domain.Roles;

namespace UserManagement.Domain.UserRoles
{
    public class UserRole
    {
        public int Id { get; set; }

        // Foreign key and navigation property for User
        public Guid UserId { get; set; }
        public User? User { get; set; }

        // Foreign key and navigation property for Role
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
