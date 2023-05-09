using Core.Persistence.Repositories;

namespace Domain.Entities;

public class RequestStatus : Entity<int>
{
    public string Name { get; set; }
}
