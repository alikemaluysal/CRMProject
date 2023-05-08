using Core.Application.Responses;

namespace Application.Features.Notifications.Commands.Update;

public class UpdatedNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}