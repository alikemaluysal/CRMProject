using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRequestStatusRepository : IAsyncRepository<RequestStatus, int>, IRepository<RequestStatus, int>
{
}