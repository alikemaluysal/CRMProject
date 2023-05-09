using Core.Application.Responses;

namespace Application.Features.TaskEntities.Commands.Delete;

public class DeletedTaskEntityResponse : IResponse
{
    public int Id { get; set; }
}