using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGenderRepository : IAsyncRepository<Gender, Guid>, IRepository<Gender, Guid>
{
}