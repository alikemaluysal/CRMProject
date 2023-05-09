using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDocumentRepository : IAsyncRepository<Document, int>, IRepository<Document, int>
{
}