using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDocumentTypeRepository : IAsyncRepository<DocumentType, int>, IRepository<DocumentType, int>
{
}