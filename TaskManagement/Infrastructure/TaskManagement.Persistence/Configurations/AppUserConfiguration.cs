using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200);

            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(200);

            builder.Property(x => x.Password).IsRequired();

            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(200);

            builder.Property(x => x.AppRoleId).IsRequired();

            builder.HasMany(x => x.Tasks).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            builder.HasMany(x => x.Notifications).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
        }
    }
}
