using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class TaskEntity : Entity<int>
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public int TaskStatusId { get; set; }

    #region Navigation Properties

    public virtual Request? Request { get; set; }
    public virtual User? EmployeeUser { get; set; }
    public virtual TaskStatus? TaskStatus { get; set; }

    #endregion
}