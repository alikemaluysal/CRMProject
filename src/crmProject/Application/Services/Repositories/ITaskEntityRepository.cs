using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITaskEntityRepository : IAsyncRepository<TaskEntity, int>, IRepository<TaskEntity, int>
{
}