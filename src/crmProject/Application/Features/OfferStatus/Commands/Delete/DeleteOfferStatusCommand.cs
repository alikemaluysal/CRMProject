using Application.Features.OfferStatus.Constants;
using Application.Features.OfferStatus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OfferStatus.Commands.Delete;

public class DeleteOfferStatusCommand : IRequest<DeletedOfferStatusResponse>
{
    public Guid Id { get; set; }

    public class DeleteOfferStatusCommandHandler : IRequestHandler<DeleteOfferStatusCommand, DeletedOfferStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly OfferStatusBusinessRules _offerStatusBusinessRules;

        public DeleteOfferStatusCommandHandler(IMapper mapper, IOfferStatusRepository offerStatusRepository,
                                         OfferStatusBusinessRules offerStatusBusinessRules)
        {
            _mapper = mapper;
            _offerStatusRepository = offerStatusRepository;
            _offerStatusBusinessRules = offerStatusBusinessRules;
        }

        public async Task<DeletedOfferStatusResponse> Handle(DeleteOfferStatusCommand request, CancellationToken cancellationToken)
        {
            OfferStatus? offerStatus = await _offerStatusRepository.GetAsync(os => os.Id == request.Id, cancellationToken: cancellationToken);
            await _offerStatusBusinessRules.OfferStatusShouldExistWhenSelected(offerStatus);

            await _offerStatusRepository.DeleteAsync(offerStatus!);

            DeletedOfferStatusResponse response = _mapper.Map<DeletedOfferStatusResponse>(offerStatus);
            return response;
        }
    }
}