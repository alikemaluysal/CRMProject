using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Enums;

namespace Domain.Entities;

public class Customer : Entity<Guid>
{
    public int UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public int? GenderId { get; set; }
    public int? TitleId { get; set; }
    public string? CompanyName { get; set; }
    public int? StatusTypeId { get; set; }
    public CustomerTypeEnum CustomerType { get; set; }
    public int? RegionId { get; set; }
    public DateTime BirthDate { get; set; }

    #region Navigation Properties

    public virtual User? UserFk { get; set; }
    public virtual StatusType? StatusTypeFk { get; set; }
    public virtual Gender? GenderFk { get; set; }
    public virtual Title? TitleFk { get; set; }

    #endregion
}