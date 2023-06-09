using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOfferStatusRepository : IAsyncRepository<OfferStatus, int>, IRepository<OfferStatus, int>
{
}