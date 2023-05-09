using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TaskEntityRepository : EfRepositoryBase<TaskEntity, int, BaseDbContext>, ITaskEntityRepository
{
    public TaskEntityRepository(BaseDbContext context) : base(context)
    {
    }
}