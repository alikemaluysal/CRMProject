using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Offer : Entity<Guid>
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public int OfferStatusId { get; set; }
}