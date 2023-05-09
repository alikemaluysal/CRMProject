using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Employee : Entity<int>
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
    public virtual User? User { get; set; }
    public virtual StatusType? StatusType { get; set; }
    public virtual Gender? Gender { get; set; }
    public virtual Title? Title { get; set; }
    public virtual Department? Department { get; set; }

    #endregion
}