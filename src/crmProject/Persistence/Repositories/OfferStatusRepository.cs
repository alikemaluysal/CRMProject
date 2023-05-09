using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OfferStatusRepository : EfRepositoryBase<OfferStatus, int, BaseDbContext>, IOfferStatusRepository
{
    public OfferStatusRepository(BaseDbContext context) : base(context)
    {
    }
}