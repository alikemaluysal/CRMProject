using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DocumentTypeRepository : EfRepositoryBase<DocumentType, int, BaseDbContext>, IDocumentTypeRepository
{
    public DocumentTypeRepository(BaseDbContext context) : base(context)
    {
    }
}