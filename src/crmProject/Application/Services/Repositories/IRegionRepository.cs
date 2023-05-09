using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRegionRepository : IAsyncRepository<Region, int>, IRepository<Region, int>
{
}