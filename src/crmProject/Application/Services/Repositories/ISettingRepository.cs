using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISettingRepository : IAsyncRepository<Setting, int>, IRepository<Setting, int>
{
}