using Core.Application.Responses;

namespace Application.Features.RequestStatuses.Commands.Create;

public class CreatedRequestStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}