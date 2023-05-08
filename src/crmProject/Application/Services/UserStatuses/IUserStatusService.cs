using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserStatuses;

public interface IUserStatusService
{
    Task<UserStatus?> GetAsync(
        Expression<Func<UserStatus, bool>> predicate,
        Func<IQueryable<UserStatus>, IIncludableQueryable<UserStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserStatus>?> GetListAsync(
        Expression<Func<UserStatus, bool>>? predicate = null,
        Func<IQueryable<UserStatus>, IOrderedQueryable<UserStatus>>? orderBy = null,
        Func<IQueryable<UserStatus>, IIncludableQueryable<UserStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserStatus> AddAsync(UserStatus userStatus);
    Task<UserStatus> UpdateAsync(UserStatus userStatus);
    Task<UserStatus> DeleteAsync(UserStatus userStatus, bool permanent = false);
}
