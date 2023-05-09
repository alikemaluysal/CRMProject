using Application.Features.RequestStatuses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.RequestStatuses.Rules;

public class RequestStatusBusinessRules : BaseBusinessRules
{
    private readonly IRequestStatusRepository _requestStatusRepository;

    public RequestStatusBusinessRules(IRequestStatusRepository requestStatusRepository)
    {
        _requestStatusRepository = requestStatusRepository;
    }

    public Task RequestStatusShouldExistWhenSelected(RequestStatus? requestStatus)
    {
        if (requestStatus == null)
            throw new BusinessException(RequestStatusBusinessMessages.RequestStatusNotExists);
        return Task.CompletedTask;
    }

    public async Task RequestStatusIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        RequestStatus? requestStatus = await _requestStatusRepository.GetAsync(
            predicate: rs => rs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RequestStatusShouldExistWhenSelected(requestStatus);
    }
}