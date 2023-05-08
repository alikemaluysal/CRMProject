using Core.Application.Responses;

namespace Application.Features.RequestStatus.Commands.Update;

public class UpdatedRequestStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}