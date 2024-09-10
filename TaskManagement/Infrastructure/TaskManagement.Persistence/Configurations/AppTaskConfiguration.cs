﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistence.Configurations
{
    public class AppTaskConfiguration : IEntityTypeConfiguration<AppTask>
    {
        public void Configure(EntityTypeBuilder<AppTask> builder)
        {
            builder.Property(x => x.PriorityId).IsRequired(true);

            builder.Property(x=>x.AppUserId).IsRequired();

            builder.Property(x=>x.Description).IsRequired();

            builder.Property(x=>x.Title).IsRequired();
            builder.Property(x=>x.Title).HasMaxLength(250);

            builder.HasMany(x => x.TaskReports).WithOne(x => x.AppTask).HasForeignKey(x => x.AppTaskId);
        }
    }
}
