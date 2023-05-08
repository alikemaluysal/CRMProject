using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStatusTypeRepository : IAsyncRepository<StatusType, Guid>, IRepository<StatusType, Guid>
{
}