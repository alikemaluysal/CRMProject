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
        
        
        #region Notifications
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Notifications.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Notifications.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Notifications.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Notifications.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Notifications.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Notifications.Delete" });
        
        #endregion
        
        
        #region Offers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Offers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Offers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Offers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Offers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Offers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Offers.Delete" });
        
        #endregion
        
        
        #region OfferStatus
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OfferStatus.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OfferStatus.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OfferStatus.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "OfferStatus.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OfferStatus.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OfferStatus.Delete" });
        
        #endregion
        
        
        #region Regions
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Regions.Delete" });
        
        #endregion
        
        
        #region Requests
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Requests.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Requests.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Requests.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Requests.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Requests.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Requests.Delete" });
        
        #endregion
        
        
        #region RequestStatus
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "RequestStatus.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "RequestStatus.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RequestStatus.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "RequestStatus.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RequestStatus.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RequestStatus.Delete" });
        
        #endregion
        
        
        #region Sales
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sales.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sales.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sales.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sales.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sales.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sales.Delete" });
        
        #endregion
        
        
        #region Settings
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Settings.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Settings.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Settings.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Settings.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Settings.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Settings.Delete" });
        
        #endregion
        
        
        #region StatusTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "StatusTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "StatusTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StatusTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "StatusTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StatusTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StatusTypes.Delete" });
        
        #endregion
        
        
        #region TaskEntities
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskEntities.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskEntities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskEntities.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskEntities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskEntities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskEntities.Delete" });
        
        #endregion
        
        
        #region Titles
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Titles.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Titles.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Titles.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Titles.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Titles.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Titles.Delete" });
        
        #endregion
        
        
        #region UserAddresses
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAddresses.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAddresses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAddresses.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAddresses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAddresses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserAddresses.Delete" });
        
        #endregion
        
        
        #region UserEmails
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserEmails.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserEmails.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserEmails.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserEmails.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserEmails.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserEmails.Delete" });
        
        #endregion
        
        
        #region UserPhones
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserPhones.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserPhones.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserPhones.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserPhones.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserPhones.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserPhones.Delete" });
        
        #endregion
        
        
        #region TaskStatus
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskStatus.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskStatus.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskStatus.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskStatus.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskStatus.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TaskStatus.Delete" });
        
        #endregion
        
        
        #region UserStatus
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserStatus.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserStatus.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserStatus.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserStatus.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserStatus.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserStatus.Delete" });
        
        #endregion
        
        return seeds;
    }
}
