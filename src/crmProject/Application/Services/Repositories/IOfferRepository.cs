using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOfferRepository : IAsyncRepository<Offer, int>, IRepository<Offer, int>
{
}