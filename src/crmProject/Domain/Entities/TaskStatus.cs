using Core.Persistence.Repositories;

namespace Domain.Entities;

public class TaskStatus : Entity<Guid>
{
    public string? Name { get; set; }

    public virtual List<Task>? Tasks { get; set; }
}
