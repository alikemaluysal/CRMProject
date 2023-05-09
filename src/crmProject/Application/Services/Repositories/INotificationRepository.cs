using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface INotificationRepository : IAsyncRepository<Notification, int>, IRepository<Notification, int>
{
}