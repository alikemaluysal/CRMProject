using Application.Features.OfferStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OfferStatuses.Commands.Update;

public class UpdateOfferStatusCommand : IRequest<UpdatedOfferStatusResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateOfferStatusCommandHandler : IRequestHandler<UpdateOfferStatusCommand, UpdatedOfferStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly OfferStatusBusinessRules _offerStatusBusinessRules;

        public UpdateOfferStatusCommandHandler(IMapper mapper, IOfferStatusRepository offerStatusRepository,
                                         OfferStatusBusinessRules offerStatusBusinessRules)
        {
            _mapper = mapper;
            _offerStatusRepository = offerStatusRepository;
            _offerStatusBusinessRules = offerStatusBusinessRules;
        }

        public async Task<UpdatedOfferStatusResponse> Handle(UpdateOfferStatusCommand request, CancellationToken cancellationToken)
        {
            OfferStatus? offerStatus = await _offerStatusRepository.GetAsync(os => os.Id == request.Id, cancellationToken: cancellationToken);
            await _offerStatusBusinessRules.OfferStatusShouldExistWhenSelected(offerStatus);
            offerStatus = _mapper.Map(request, offerStatus);

            await _offerStatusBusinessRules.OfferStatusNameShouldNotExistWhenUpdating(offerStatus);


            await _offerStatusRepository.UpdateAsync(offerStatus);

            UpdatedOfferStatusResponse response = _mapper.Map<UpdatedOfferStatusResponse>(offerStatus);
            return response;
        }
    }
}