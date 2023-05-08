using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserStatusRepository : EfRepositoryBase<UserStatus, Guid, BaseDbContext>, IUserStatusRepository
{
    public UserStatusRepository(BaseDbContext context) : base(context)
    {
    }
}