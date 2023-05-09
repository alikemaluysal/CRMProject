using Core.Application.Responses;

namespace Application.Features.TaskStatuses.Commands.Delete;

public class DeletedTaskStatusResponse : IResponse
{
    public int Id { get; set; }
}