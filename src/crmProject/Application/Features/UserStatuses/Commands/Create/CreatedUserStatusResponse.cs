using Core.Application.Responses;

namespace Application.Features.UserStatuses.Commands.Create;

public class CreatedUserStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}