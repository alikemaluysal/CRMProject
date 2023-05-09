using Application.Features.StatusTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StatusTypes.Rules;

public class StatusTypeBusinessRules : BaseBusinessRules
{
    private readonly IStatusTypeRepository _statusTypeRepository;

    public StatusTypeBusinessRules(IStatusTypeRepository statusTypeRepository)
    {
        _statusTypeRepository = statusTypeRepository;
    }

    public Task StatusTypeShouldExistWhenSelected(StatusType? statusType)
    {
        if (statusType == null)
            throw new BusinessException(StatusTypesBusinessMessages.StatusTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task StatusTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        StatusType? statusType = await _statusTypeRepository.GetAsync(
            predicate: st => st.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StatusTypeShouldExistWhenSelected(statusType);
    }
}