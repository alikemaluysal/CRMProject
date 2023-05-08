using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Offers.Queries.GetList;

public class GetListOfferQuery : IRequest<GetListResponse<GetListOfferListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOfferQueryHandler : IRequestHandler<GetListOfferQuery, GetListResponse<GetListOfferListItemDto>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public GetListOfferQueryHandler(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOfferListItemDto>> Handle(GetListOfferQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Offer> offers = await _offerRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOfferListItemDto> response = _mapper.Map<GetListResponse<GetListOfferListItemDto>>(offers);
            return response;
        }
    }
}