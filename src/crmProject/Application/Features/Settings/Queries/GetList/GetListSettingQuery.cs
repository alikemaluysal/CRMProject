using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Settings.Queries.GetList;

public class GetListSettingQuery : IRequest<GetListResponse<GetListSettingListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSettingQueryHandler : IRequestHandler<GetListSettingQuery, GetListResponse<GetListSettingListItemDto>>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public GetListSettingQueryHandler(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSettingListItemDto>> Handle(GetListSettingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Setting> settings = await _settingRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSettingListItemDto> response = _mapper.Map<GetListResponse<GetListSettingListItemDto>>(settings);
            return response;
        }
    }
}