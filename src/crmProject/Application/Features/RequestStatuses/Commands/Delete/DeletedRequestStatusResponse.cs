using Core.Application.Responses;

namespace Application.Features.RequestStatuses.Commands.Delete;

public class DeletedRequestStatusResponse : IResponse
{
    public int Id { get; set; }
}