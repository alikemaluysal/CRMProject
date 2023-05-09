using Application.Features.Requests.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Requests.Rules;

public class RequestBusinessRules : BaseBusinessRules
{
    private readonly IRequestRepository _requestRepository;

    public RequestBusinessRules(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public Task RequestShouldExistWhenSelected(Request? request)
    {
        if (request == null)
            throw new BusinessException(RequestsBusinessMessages.RequestNotExists);
        return Task.CompletedTask;
    }

    public async Task RequestIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Request? request = await _requestRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RequestShouldExistWhenSelected(request);
    }
}