using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DocumentRepository : EfRepositoryBase<Document, int, BaseDbContext>, IDocumentRepository
{
    public DocumentRepository(BaseDbContext context) : base(context)
    {
    }
}