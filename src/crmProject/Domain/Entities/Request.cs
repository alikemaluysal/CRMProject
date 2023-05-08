using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Request : Entity<Guid>
{
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string Description { get; set; }
}