using Core.Application.Responses;

namespace Application.Features.UserStatuses.Commands.Update;

public class UpdatedUserStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}