using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
{
    public void Configure(EntityTypeBuilder<UserStatus> builder)
    {
        builder.ToTable("UserStatus").HasKey(us => us.Id);

        builder.Property(us => us.Id).HasColumnName("Id").IsRequired();
        builder.Property(us => us.Name).HasColumnName("Name");
        builder.Property(us => us.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(us => us.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(us => us.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(us => !us.DeletedDate.HasValue);
    }
}