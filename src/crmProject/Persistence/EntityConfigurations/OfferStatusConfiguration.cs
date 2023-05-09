using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OfferStatusConfiguration : IEntityTypeConfiguration<OfferStatus>
{
    public void Configure(EntityTypeBuilder<OfferStatus> builder)
    {
        builder.ToTable("OfferStatus").HasKey(os => os.Id);

        builder.Property(os => os.Id).HasColumnName("Id").IsRequired();
        builder.Property(os => os.Name).HasColumnName("Name");
        builder.Property(os => os.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(os => os.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(os => os.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(os => !os.DeletedDate.HasValue);

        OfferStatus[] offerStatusSeeds = new OfferStatus[]
        {
                new() {Id = 1, Name = "Open" },
                new() {Id = 2, Name = "In Progress" },
                new() {Id = 3, Name = "Resolved" },
                new() {Id = 4, Name = "Closed" }
        };

        builder.HasData(offerStatusSeeds);
    }
}