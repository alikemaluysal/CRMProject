using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Enums;

namespace Domain.Entities;

public class Customer : Entity<int>
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

    public virtual User? User { get; set; }
    public virtual StatusType? StatusType { get; set; }
    public virtual Gender? Gender { get; set; }
    public virtual Title? Title { get; set; }
    public virtual Region? Region { get; set; }

    #endregion
}