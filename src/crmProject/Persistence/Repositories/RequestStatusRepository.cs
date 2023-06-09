using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequestStatusRepository : EfRepositoryBase<RequestStatus, int, BaseDbContext>, IRequestStatusRepository
{
    public RequestStatusRepository(BaseDbContext context) : base(context)
    {
    }
}