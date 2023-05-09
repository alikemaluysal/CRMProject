using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserPhoneRepository : EfRepositoryBase<UserPhone, int, BaseDbContext>, IUserPhoneRepository
{
    public UserPhoneRepository(BaseDbContext context) : base(context)
    {
    }
}