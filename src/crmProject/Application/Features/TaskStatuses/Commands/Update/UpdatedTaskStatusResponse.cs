using Core.Application.Responses;

namespace Application.Features.TaskStatuses.Commands.Update;

public class UpdatedTaskStatusResponse : IResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
}