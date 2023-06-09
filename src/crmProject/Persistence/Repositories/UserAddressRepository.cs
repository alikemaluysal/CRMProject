using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserAddressRepository : EfRepositoryBase<UserAddress, int, BaseDbContext>, IUserAddressRepository
{
    public UserAddressRepository(BaseDbContext context) : base(context)
    {
    }
}