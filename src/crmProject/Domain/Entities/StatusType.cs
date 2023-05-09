using Core.Persistence.Repositories;

namespace Domain.Entities;

public class StatusType : Entity<int>
{
    public string Name { get; set; }

    public virtual List<Customer>? Customers { get; set; }
}