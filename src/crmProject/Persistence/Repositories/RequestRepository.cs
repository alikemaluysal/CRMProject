using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequestRepository : EfRepositoryBase<Request, int, BaseDbContext>, IRequestRepository
{
    public RequestRepository(BaseDbContext context) : base(context)
    {
    }
}