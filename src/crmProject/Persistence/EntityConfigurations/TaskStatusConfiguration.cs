using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Persistence.EntityConfigurations;

public class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatus>
{
    public void Configure(EntityTypeBuilder<TaskStatus> builder)
    {
        builder.ToTable("TaskStatus").HasKey(ts => ts.Id);

        builder.Property(ts => ts.Id).HasColumnName("Id").IsRequired();
        builder.Property(ts => ts.Name).HasColumnName("Name");
        builder.Property(ts => ts.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ts => ts.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ts => ts.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ts => !ts.DeletedDate.HasValue);

        TaskStatus[] taskStatusSeeds = new TaskStatus[]
        {
                new() {Id = 1, Name = "Open" },
                new() {Id = 2, Name = "In Progress" },
                new() {Id = 3, Name = "Resolved" },
                new() {Id = 4, Name = "Closed" }
        };

        builder.HasData(taskStatusSeeds);


    }
}