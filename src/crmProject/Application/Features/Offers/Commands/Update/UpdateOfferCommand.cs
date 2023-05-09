using Application.Features.Offers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Offers.Commands.Update;

public class UpdateOfferCommand : IRequest<UpdatedOfferResponse>
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public int OfferStatusId { get; set; }

    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, UpdatedOfferResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly OfferBusinessRules _offerBusinessRules;

        public UpdateOfferCommandHandler(IMapper mapper, IOfferRepository offerRepository,
                                         OfferBusinessRules offerBusinessRules)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _offerBusinessRules = offerBusinessRules;
        }

        public async Task<UpdatedOfferResponse> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            Offer? offer = await _offerRepository.GetAsync(o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _offerBusinessRules.OfferShouldExistWhenSelected(offer);
            offer = _mapper.Map(request, offer);

            await _offerRepository.UpdateAsync(offer);

            UpdatedOfferResponse response = _mapper.Map<UpdatedOfferResponse>(offer);
            return response;
        }
    }
}