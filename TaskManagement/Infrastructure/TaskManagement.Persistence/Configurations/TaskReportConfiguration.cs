﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistence.Configurations
{
    public class TaskReportConfiguration : IEntityTypeConfiguration<TaskReport>
    {
        public void Configure(EntityTypeBuilder<TaskReport> builder)
        {
            builder.Property(x => x.Definition).IsRequired();
            builder.Property(x => x.Definition).HasMaxLength(250);

            builder.Property(x => x.Detail).IsRequired();

            builder.Property(x => x.AppTaskId).IsRequired();
        }
    }
}
