using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserEmailRepository : IAsyncRepository<UserEmail, Guid>, IRepository<UserEmail, Guid>
{
}