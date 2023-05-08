using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserStatuses.Queries.GetList;

public class GetListUserStatusQuery : IRequest<GetListResponse<GetListUserStatusListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserStatusQueryHandler : IRequestHandler<GetListUserStatusQuery, GetListResponse<GetListUserStatusListItemDto>>
    {
        private readonly IUserStatusRepository _userStatusRepository;
        private readonly IMapper _mapper;

        public GetListUserStatusQueryHandler(IUserStatusRepository userStatusRepository, IMapper mapper)
        {
            _userStatusRepository = userStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserStatusListItemDto>> Handle(GetListUserStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserStatus> userStatus = await _userStatusRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserStatusListItemDto> response = _mapper.Map<GetListResponse<GetListUserStatusListItemDto>>(userStatus);
            return response;
        }
    }
}