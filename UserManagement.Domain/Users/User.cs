using UserManagement.Domain.Enums;
using UserManagement.Domain.UserRoles;

namespace UserManagement.Domain.Users { }

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Active;


    // Navigation property
    public ICollection<UserRole>? UserRoles { get; set; }
}

