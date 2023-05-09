using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDepartmentRepository : IAsyncRepository<Department, int>, IRepository<Department, int>
{
}