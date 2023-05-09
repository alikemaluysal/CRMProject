using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEmployeeRepository : IAsyncRepository<Employee, int>, IRepository<Employee, int>
{
}