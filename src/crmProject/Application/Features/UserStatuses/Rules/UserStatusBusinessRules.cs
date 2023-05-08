using Application.Features.UserStatuses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserStatuses.Rules;

public class UserStatusBusinessRules : BaseBusinessRules
{
    private readonly IUserStatusRepository _userStatusRepository;

    public UserStatusBusinessRules(IUserStatusRepository userStatusRepository)
    {
        _userStatusRepository = userStatusRepository;
    }

    public Task UserStatusShouldExistWhenSelected(UserStatus? userStatus)
    {
        if (userStatus == null)
            throw new BusinessException(UserStatusBusinessMessages.UserStatusNotExists);
        return Task.CompletedTask;
    }

    public async Task UserStatusIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserStatus? userStatus = await _userStatusRepository.GetAsync(
            predicate: us => us.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserStatusShouldExistWhenSelected(userStatus);
    }
}