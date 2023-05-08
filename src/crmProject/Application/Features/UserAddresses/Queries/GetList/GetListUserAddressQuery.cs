using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserAddresses.Queries.GetList;

public class GetListUserAddressQuery : IRequest<GetListResponse<GetListUserAddressListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserAddressQueryHandler : IRequestHandler<GetListUserAddressQuery, GetListResponse<GetListUserAddressListItemDto>>
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;

        public GetListUserAddressQueryHandler(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserAddressListItemDto>> Handle(GetListUserAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserAddress> userAddresses = await _userAddressRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserAddressListItemDto> response = _mapper.Map<GetListResponse<GetListUserAddressListItemDto>>(userAddresses);
            return response;
        }
    }
}