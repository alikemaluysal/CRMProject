using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDocumentRepository : IAsyncRepository<Document, Guid>, IRepository<Document, Guid>
{
}