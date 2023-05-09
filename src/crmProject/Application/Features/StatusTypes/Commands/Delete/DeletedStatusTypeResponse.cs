using Core.Application.Responses;

namespace Application.Features.StatusTypes.Commands.Delete;

public class DeletedStatusTypeResponse : IResponse
{
    public int Id { get; set; }
}