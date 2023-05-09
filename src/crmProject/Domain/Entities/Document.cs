using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Document : Entity<int>
{
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public int DocumentTypeId { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }
    public virtual Request Request { get; set; }
    public virtual DocumentType DocumentType { get; set; }

    #endregion
}