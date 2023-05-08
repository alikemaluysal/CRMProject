using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOfferRepository : IAsyncRepository<Offer, Guid>, IRepository<Offer, Guid>
{
}