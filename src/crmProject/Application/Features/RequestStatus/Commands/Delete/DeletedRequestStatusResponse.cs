using Core.Application.Responses;

namespace Application.Features.RequestStatus.Commands.Delete;

public class DeletedRequestStatusResponse : IResponse
{
    public Guid Id { get; set; }
}