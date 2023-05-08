using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Requests.Queries.GetList;

public class GetListRequestQuery : IRequest<GetListResponse<GetListRequestListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRequestQueryHandler : IRequestHandler<GetListRequestQuery, GetListResponse<GetListRequestListItemDto>>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetListRequestQueryHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRequestListItemDto>> Handle(GetListRequestQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Request> requests = await _requestRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRequestListItemDto> response = _mapper.Map<GetListResponse<GetListRequestListItemDto>>(requests);
            return response;
        }
    }
}