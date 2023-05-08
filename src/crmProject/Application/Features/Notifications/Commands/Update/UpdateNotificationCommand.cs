using Application.Features.Notifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Commands.Update;

public class UpdateNotificationCommand : IRequest<UpdatedNotificationResponse>
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, UpdatedNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly NotificationBusinessRules _notificationBusinessRules;

        public UpdateNotificationCommandHandler(IMapper mapper, INotificationRepository notificationRepository,
                                         NotificationBusinessRules notificationBusinessRules)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _notificationBusinessRules = notificationBusinessRules;
        }

        public async Task<UpdatedNotificationResponse> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            Notification? notification = await _notificationRepository.GetAsync(n => n.Id == request.Id, cancellationToken: cancellationToken);
            await _notificationBusinessRules.NotificationShouldExistWhenSelected(notification);
            notification = _mapper.Map(request, notification);

            await _notificationRepository.UpdateAsync(notification);

            UpdatedNotificationResponse response = _mapper.Map<UpdatedNotificationResponse>(notification);
            return response;
        }
    }
}