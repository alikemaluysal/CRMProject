using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Notifications.Queries.GetList;

public class GetListNotificationQuery : IRequest<GetListResponse<GetListNotificationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListNotificationQueryHandler : IRequestHandler<GetListNotificationQuery, GetListResponse<GetListNotificationListItemDto>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetListNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListNotificationListItemDto>> Handle(GetListNotificationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Notification> notifications = await _notificationRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListNotificationListItemDto> response = _mapper.Map<GetListResponse<GetListNotificationListItemDto>>(notifications);
            return response;
        }
    }
}