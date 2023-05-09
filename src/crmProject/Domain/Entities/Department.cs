using Core.Persistence.Repositories;


namespace Domain.Entities;

public class Department : Entity<int>
{
    public string? Name { get; set; }

}