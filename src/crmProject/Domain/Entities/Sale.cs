using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Sale : Entity<Guid>
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SaleAmount { get; set; }
    public string Description { get; set; }
}