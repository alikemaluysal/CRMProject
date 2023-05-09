using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Notification : Entity<int>
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;


    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}