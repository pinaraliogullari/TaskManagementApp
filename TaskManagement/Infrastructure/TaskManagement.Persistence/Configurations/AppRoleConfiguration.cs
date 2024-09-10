using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistence.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).IsRequired();
            builder.Property(x => x.Definition).HasMaxLength(150);

            builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.AppRoleId);
        }
    }
}
