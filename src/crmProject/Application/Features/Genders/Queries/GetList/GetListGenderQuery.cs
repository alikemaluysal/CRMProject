using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Genders.Queries.GetList;

public class GetListGenderQuery : IRequest<GetListResponse<GetListGenderListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGenderQueryHandler : IRequestHandler<GetListGenderQuery, GetListResponse<GetListGenderListItemDto>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GetListGenderQueryHandler(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGenderListItemDto>> Handle(GetListGenderQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Gender> genders = await _genderRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGenderListItemDto> response = _mapper.Map<GetListResponse<GetListGenderListItemDto>>(genders);
            return response;
        }
    }
}