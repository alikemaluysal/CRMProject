using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRequestRepository : IAsyncRepository<Request, int>, IRepository<Request, int>
{
}