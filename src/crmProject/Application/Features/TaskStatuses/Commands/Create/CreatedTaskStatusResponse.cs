using Core.Application.Responses;

namespace Application.Features.TaskStatuses.Commands.Create;

public class CreatedTaskStatusResponse : IResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
}