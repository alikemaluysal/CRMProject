using Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserStatus : Entity<Guid>
{
    public string Name { get; set; }
}