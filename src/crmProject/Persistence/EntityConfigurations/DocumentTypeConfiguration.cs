using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder.ToTable("DocumentTypes").HasKey(dt => dt.Id);

        builder.Property(dt => dt.Id).HasColumnName("Id").IsRequired();
        builder.Property(dt => dt.Name).HasColumnName("Name");
        builder.Property(dt => dt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(dt => dt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(dt => dt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(dt => !dt.DeletedDate.HasValue);
    }
}