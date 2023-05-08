using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Task : Entity<Guid>
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public int TaskStatusId { get; set; }

    #region Navigation Properties

    public virtual Request? RequestFK { get; set; }
    public virtual Employee? EmployeeFK { get; set; }
    public virtual TaskStatus? TaskStatusFK { get; set; }

    #endregion
}