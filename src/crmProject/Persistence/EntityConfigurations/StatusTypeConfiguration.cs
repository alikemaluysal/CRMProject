using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StatusTypeConfiguration : IEntityTypeConfiguration<StatusType>
{
    public void Configure(EntityTypeBuilder<StatusType> builder)
    {
        builder.ToTable("StatusTypes").HasKey(st => st.Id);

        builder.Property(st => st.Id).HasColumnName("Id").IsRequired();
        builder.Property(st => st.Name).HasColumnName("Name");
        builder.Property(st => st.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(st => st.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(st => st.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(st => !st.DeletedDate.HasValue);

        StatusType[] statusTypeSeeds = new StatusType[]
        {
                new() {Id = 1, Name = "Active" },
                new() {Id = 2, Name = "Archive" },
                new() {Id = 3, Name = "Black Listed" }
        };

        builder.HasData(statusTypeSeeds);


    }
}