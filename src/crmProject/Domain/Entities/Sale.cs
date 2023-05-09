using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Sale : Entity<int>
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SaleAmount { get; set; }
    public string Description { get; set; }

    #region Navigation Properties

    public virtual User? EmployeeUser { get; set; }
    public virtual Request Request { get; set; }

    #endregion
}