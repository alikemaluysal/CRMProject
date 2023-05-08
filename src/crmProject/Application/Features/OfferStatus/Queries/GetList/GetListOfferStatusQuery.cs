using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.OfferStatus.Queries.GetList;

public class GetListOfferStatusQuery : IRequest<GetListResponse<GetListOfferStatusListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOfferStatusQueryHandler : IRequestHandler<GetListOfferStatusQuery, GetListResponse<GetListOfferStatusListItemDto>>
    {
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly IMapper _mapper;

        public GetListOfferStatusQueryHandler(IOfferStatusRepository offerStatusRepository, IMapper mapper)
        {
            _offerStatusRepository = offerStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOfferStatusListItemDto>> Handle(GetListOfferStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OfferStatus> offerStatus = await _offerStatusRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOfferStatusListItemDto> response = _mapper.Map<GetListResponse<GetListOfferStatusListItemDto>>(offerStatus);
            return response;
        }
    }
}