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

        DocumentType[] documentTypeSeeds = new DocumentType[]
        {
                new() {Id = 1, Name = "Word" },
                new() {Id = 2, Name = "PDF" },
                new() {Id = 3, Name = "Video" },
                new() {Id = 4, Name = "Audio" }
        };

        builder.HasData(documentTypeSeeds);
    }
}