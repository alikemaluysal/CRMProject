using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Notification : Entity<Guid>
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}