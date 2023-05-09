using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SettingRepository : EfRepositoryBase<Setting, int, BaseDbContext>, ISettingRepository
{
    public SettingRepository(BaseDbContext context) : base(context)
    {
    }
}