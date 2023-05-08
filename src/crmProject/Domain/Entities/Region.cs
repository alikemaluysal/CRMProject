using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Region : Entity<Guid>
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
}