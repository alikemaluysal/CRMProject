using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserPhones.Queries.GetList;

public class GetListUserPhoneQuery : IRequest<GetListResponse<GetListUserPhoneListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserPhoneQueryHandler : IRequestHandler<GetListUserPhoneQuery, GetListResponse<GetListUserPhoneListItemDto>>
    {
        private readonly IUserPhoneRepository _userPhoneRepository;
        private readonly IMapper _mapper;

        public GetListUserPhoneQueryHandler(IUserPhoneRepository userPhoneRepository, IMapper mapper)
        {
            _userPhoneRepository = userPhoneRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserPhoneListItemDto>> Handle(GetListUserPhoneQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserPhone> userPhones = await _userPhoneRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserPhoneListItemDto> response = _mapper.Map<GetListResponse<GetListUserPhoneListItemDto>>(userPhones);
            return response;
        }
    }
}