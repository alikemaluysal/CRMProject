using Application.Features.OfferStatus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OfferStatus.Commands.Create;

public class CreateOfferStatusCommand : IRequest<CreatedOfferStatusResponse>
{
    public string Name { get; set; }

    public class CreateOfferStatusCommandHandler : IRequestHandler<CreateOfferStatusCommand, CreatedOfferStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly OfferStatusBusinessRules _offerStatusBusinessRules;

        public CreateOfferStatusCommandHandler(IMapper mapper, IOfferStatusRepository offerStatusRepository,
                                         OfferStatusBusinessRules offerStatusBusinessRules)
        {
            _mapper = mapper;
            _offerStatusRepository = offerStatusRepository;
            _offerStatusBusinessRules = offerStatusBusinessRules;
        }

        public async Task<CreatedOfferStatusResponse> Handle(CreateOfferStatusCommand request, CancellationToken cancellationToken)
        {
            OfferStatus offerStatus = _mapper.Map<OfferStatus>(request);

            await _offerStatusRepository.AddAsync(offerStatus);

            CreatedOfferStatusResponse response = _mapper.Map<CreatedOfferStatusResponse>(offerStatus);
            return response;
        }
    }
}