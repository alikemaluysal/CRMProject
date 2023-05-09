using Core.Application.Responses;

namespace Application.Features.Notifications.Commands.Create;

public class CreatedNotificationResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}