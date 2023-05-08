using Domain.Entities;
using Core.Persistence.Repositories;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Services.Repositories;

public interface ITaskStatusRepository : IAsyncRepository<TaskStatus, Guid>, IRepository<TaskStatus, Guid>
{
}