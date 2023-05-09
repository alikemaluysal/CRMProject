using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Offer : Entity<int>
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public int OfferStatusId { get; set; }


    #region Navigation Properties

    public virtual User? EmployeeUser { get; set; }
    public virtual Request Request { get; set; }
    public virtual OfferStatus OfferStatus { get; set; }

    #endregion
}