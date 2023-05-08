using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Employee : Entity<Guid>
{
    public int UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public int? GenderId { get; set; }
    public int? TitleId { get; set; }
    public int? DepartmentId { get; set; }
    public DateTime? StartDate { get; set; }
    public int? StatusTypeId { get; set; }
    public int? RegionId { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? ParentEmployeeId { get; set; }

    #region Navigation Properties
    public virtual User? UserFk { get; set; }
    public virtual StatusType? StatusTypeFk { get; set; }
    public virtual Gender? GenderFk { get; set; }
    public virtual Title? TitleFk { get; set; }
    public virtual Department? DepartmentFk { get; set; }

    #endregion
}