using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITaskEntityRepository : IAsyncRepository<TaskEntity, Guid>, IRepository<TaskEntity, Guid>
{
}