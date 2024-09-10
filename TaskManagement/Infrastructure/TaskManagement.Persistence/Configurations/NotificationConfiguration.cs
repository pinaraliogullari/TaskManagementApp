using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.Property(x => x.AppUserId).IsRequired();

            builder.Property(x => x.State).IsRequired();
        }
    }
}
