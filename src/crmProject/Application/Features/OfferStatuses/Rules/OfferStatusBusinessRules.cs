using Application.Features.OfferStatuses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.OfferStatuses.Rules;

public class OfferStatusBusinessRules : BaseBusinessRules
{
    private readonly IOfferStatusRepository _offerStatusRepository;

    public OfferStatusBusinessRules(IOfferStatusRepository offerStatusRepository)
    {
        _offerStatusRepository = offerStatusRepository;
    }

    public Task OfferStatusShouldExistWhenSelected(OfferStatus? offerStatus)
    {
        if (offerStatus == null)
            throw new BusinessException(OfferStatusBusinessMessages.OfferStatusNotExists);
        return Task.CompletedTask;
    }

    public async Task OfferStatusIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        OfferStatus? offerStatus = await _offerStatusRepository.GetAsync(
            predicate: os => os.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OfferStatusShouldExistWhenSelected(offerStatus);
    }
}