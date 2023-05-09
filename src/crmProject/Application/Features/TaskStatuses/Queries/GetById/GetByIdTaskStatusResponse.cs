using Core.Application.Responses;

namespace Application.Features.TaskStatuses.Queries.GetById;

public class GetByIdTaskStatusResponse : IResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
}