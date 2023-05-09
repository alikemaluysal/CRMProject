using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStatusTypeRepository : IAsyncRepository<StatusType, int>, IRepository<StatusType, int>
{
}