using Core.Application.Responses;

namespace Application.Features.RequestStatus.Commands.Create;

public class CreatedRequestStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}