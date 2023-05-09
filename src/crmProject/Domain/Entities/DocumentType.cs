using Core.Persistence.Repositories;


namespace Domain.Entities;

public class DocumentType : Entity<int>
{
    public string? Name { get; set; }
}
