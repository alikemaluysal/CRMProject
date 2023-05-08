using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Document : Entity<Guid>
{
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public int DocumentTypeId { get; set; }
}