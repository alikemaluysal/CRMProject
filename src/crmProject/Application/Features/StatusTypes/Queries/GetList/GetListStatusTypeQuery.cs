using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StatusTypes.Queries.GetList;

public class GetListStatusTypeQuery : IRequest<GetListResponse<GetListStatusTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStatusTypeQueryHandler : IRequestHandler<GetListStatusTypeQuery, GetListResponse<GetListStatusTypeListItemDto>>
    {
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly IMapper _mapper;

        public GetListStatusTypeQueryHandler(IStatusTypeRepository statusTypeRepository, IMapper mapper)
        {
            _statusTypeRepository = statusTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStatusTypeListItemDto>> Handle(GetListStatusTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StatusType> statusTypes = await _statusTypeRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStatusTypeListItemDto> response = _mapper.Map<GetListResponse<GetListStatusTypeListItemDto>>(statusTypes);
            return response;
        }
    }
}