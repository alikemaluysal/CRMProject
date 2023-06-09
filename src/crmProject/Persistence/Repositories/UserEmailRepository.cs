using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserEmailRepository : EfRepositoryBase<UserEmail, int, BaseDbContext>, IUserEmailRepository
{
    public UserEmailRepository(BaseDbContext context) : base(context)
    {
    }
}