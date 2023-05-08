using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Customers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Delete" });
        
        #endregion
        
        
        #region Departments
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Departments.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Departments.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Departments.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Departments.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Departments.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Departments.Delete" });
        
        #endregion
        
        
        #region Documents
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Documents.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Documents.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Documents.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Documents.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Documents.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Documents.Delete" });
        
        #endregion
        
        
        #region DocumentTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "DocumentTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "DocumentTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "DocumentTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "DocumentTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "DocumentTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "DocumentTypes.Delete" });
        
        #endregion
        
        
        #region Employees
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Employees.Delete" });
        
        #endregion
        
        
        #region Genders
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Genders.Delete" });
        
        #endregion
        
        return seeds;
    }
}
