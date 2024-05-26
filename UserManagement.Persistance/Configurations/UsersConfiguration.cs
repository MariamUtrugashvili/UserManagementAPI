using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Enums;

namespace UserManagement.Persistance.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.HasQueryFilter(x => x.Status != UserStatus.Deleted);
        }
    }
}
