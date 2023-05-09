using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITitleRepository : IAsyncRepository<Title, int>, IRepository<Title, int>
{
}