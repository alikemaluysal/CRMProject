using Core.Application.Responses;

namespace Application.Features.Requests.Commands.Delete;

public class DeletedRequestResponse : IResponse
{
    public int Id { get; set; }
}