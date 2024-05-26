using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Roles;
using UserManagement.Domain.UserRoles;


namespace UserManagement.Persistance.Context { }

public class UserManagementDbContext : DbContext
{
    public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserManagementDbContext).Assembly);

        #region Seed Roles
        var userRoleId = Guid.NewGuid();
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = userRoleId,
            RoleName = "User"

        });

        var adminRoleId = Guid.NewGuid();
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = adminRoleId,
            RoleName = "Admin"
        });

        #endregion

        #region Seed User
        var userId = Guid.NewGuid();

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = userId,
                UserName = "User",
                Email = "User@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("User123!")
            }
        );

        // Add the user role to the user
        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { Id = 1, UserId = userId, RoleId = userRoleId }
        );

        #endregion

        #region Seed Admin
        var adminId = Guid.NewGuid();

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = adminId,
                UserName = "Admin",
                Email = "Admin@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Admin123!")

            }
        );

        // Add the admin role to the admin
        modelBuilder.Entity<UserRole>().HasData(
         new UserRole { Id = 2, UserId = adminId, RoleId = adminRoleId }
        );

        #endregion

    }
}


