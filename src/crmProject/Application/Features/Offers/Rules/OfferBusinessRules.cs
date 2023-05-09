using Application.Features.Offers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Offers.Rules;

public class OfferBusinessRules : BaseBusinessRules
{
    private readonly IOfferRepository _offerRepository;

    public OfferBusinessRules(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    public Task OfferShouldExistWhenSelected(Offer? offer)
    {
        if (offer == null)
            throw new BusinessException(OffersBusinessMessages.OfferNotExists);
        return Task.CompletedTask;
    }

    public async Task OfferIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Offer? offer = await _offerRepository.GetAsync(
            predicate: o => o.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OfferShouldExistWhenSelected(offer);
    }
}