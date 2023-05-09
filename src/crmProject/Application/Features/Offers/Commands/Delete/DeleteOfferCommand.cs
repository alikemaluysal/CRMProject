using Application.Features.Offers.Constants;
using Application.Features.Offers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Offers.Commands.Delete;

public class DeleteOfferCommand : IRequest<DeletedOfferResponse>
{
    public int Id { get; set; }

    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, DeletedOfferResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly OfferBusinessRules _offerBusinessRules;

        public DeleteOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository,
                                         OfferBusinessRules offerBusinessRules)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _offerBusinessRules = offerBusinessRules;
        }

        public async Task<DeletedOfferResponse> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            Offer? offer = await _offerRepository.GetAsync(o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _offerBusinessRules.OfferShouldExistWhenSelected(offer);

            await _offerRepository.DeleteAsync(offer!);

            DeletedOfferResponse response = _mapper.Map<DeletedOfferResponse>(offer);
            return response;
        }
    }
}