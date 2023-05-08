using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserStatusRepository : IAsyncRepository<UserStatus, Guid>, IRepository<UserStatus, Guid>
{
}