using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.RequestStatus.Queries.GetList;

public class GetListRequestStatusQuery : IRequest<GetListResponse<GetListRequestStatusListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRequestStatusQueryHandler : IRequestHandler<GetListRequestStatusQuery, GetListResponse<GetListRequestStatusListItemDto>>
    {
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly IMapper _mapper;

        public GetListRequestStatusQueryHandler(IRequestStatusRepository requestStatusRepository, IMapper mapper)
        {
            _requestStatusRepository = requestStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRequestStatusListItemDto>> Handle(GetListRequestStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RequestStatus> requestStatus = await _requestStatusRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRequestStatusListItemDto> response = _mapper.Map<GetListResponse<GetListRequestStatusListItemDto>>(requestStatus);
            return response;
        }
    }
}