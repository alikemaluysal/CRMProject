using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserPhoneRepository : IAsyncRepository<UserPhone, Guid>, IRepository<UserPhone, Guid>
{
}