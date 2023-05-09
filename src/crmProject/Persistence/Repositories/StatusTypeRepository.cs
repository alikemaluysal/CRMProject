using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StatusTypeRepository : EfRepositoryBase<StatusType, int, BaseDbContext>, IStatusTypeRepository
{
    public StatusTypeRepository(BaseDbContext context) : base(context)
    {
    }
}