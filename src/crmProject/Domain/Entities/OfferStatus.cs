using Core.Persistence.Repositories;

namespace Domain.Entities;

public class OfferStatus : Entity<int>
{
    public string Name { get; set; }
}