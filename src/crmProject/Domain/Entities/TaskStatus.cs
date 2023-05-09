using Core.Persistence.Repositories;

namespace Domain.Entities;

public class TaskStatus : Entity<int>
{
    public string? Name { get; set; }

    public virtual List<TaskEntity>? Tasks { get; set; }
}
