using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDocumentTypeRepository : IAsyncRepository<DocumentType, Guid>, IRepository<DocumentType, Guid>
{
}