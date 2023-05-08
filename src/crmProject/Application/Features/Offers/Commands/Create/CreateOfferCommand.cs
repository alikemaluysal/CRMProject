using Application.Features.Offers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Offers.Commands.Create;

public class CreateOfferCommand : IRequest<CreatedOfferResponse>
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public int OfferStatusId { get; set; }

    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, CreatedOfferResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly OfferBusinessRules _offerBusinessRules;

        public CreateOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository,
                                         OfferBusinessRules offerBusinessRules)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _offerBusinessRules = offerBusinessRules;
        }

        public async Task<CreatedOfferResponse> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            Offer offer = _mapper.Map<Offer>(request);

            await _offerRepository.AddAsync(offer);

            CreatedOfferResponse response = _mapper.Map<CreatedOfferResponse>(offer);
            return response;
        }
    }
}