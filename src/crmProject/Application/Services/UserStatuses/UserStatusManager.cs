using Application.Features.UserStatuses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserStatuses;

public class UserStatusManager : IUserStatusService
{
    private readonly IUserStatusRepository _userStatusRepository;
    private readonly UserStatusBusinessRules _userStatusBusinessRules;

    public UserStatusManager(IUserStatusRepository userStatusRepository, UserStatusBusinessRules userStatusBusinessRules)
    {
        _userStatusRepository = userStatusRepository;
        _userStatusBusinessRules = userStatusBusinessRules;
    }

    public async Task<UserStatus?> GetAsync(
        Expression<Func<UserStatus, bool>> predicate,
        Func<IQueryable<UserStatus>, IIncludableQueryable<UserStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserStatus? userStatus = await _userStatusRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userStatus;
    }

    public async Task<IPaginate<UserStatus>?> GetListAsync(
        Expression<Func<UserStatus, bool>>? predicate = null,
        Func<IQueryable<UserStatus>, IOrderedQueryable<UserStatus>>? orderBy = null,
        Func<IQueryable<UserStatus>, IIncludableQueryable<UserStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserStatus> userStatusList = await _userStatusRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userStatusList;
    }

    public async Task<UserStatus> AddAsync(UserStatus userStatus)
    {
        UserStatus addedUserStatus = await _userStatusRepository.AddAsync(userStatus);

        return addedUserStatus;
    }

    public async Task<UserStatus> UpdateAsync(UserStatus userStatus)
    {
        UserStatus updatedUserStatus = await _userStatusRepository.UpdateAsync(userStatus);

        return updatedUserStatus;
    }

    public async Task<UserStatus> DeleteAsync(UserStatus userStatus, bool permanent = false)
    {
        UserStatus deletedUserStatus = await _userStatusRepository.DeleteAsync(userStatus);

        return deletedUserStatus;
    }
}
