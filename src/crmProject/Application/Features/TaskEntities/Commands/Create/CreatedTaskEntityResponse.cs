using Core.Application.Responses;

namespace Application.Features.TaskEntities.Commands.Create;

public class CreatedTaskEntityResponse : IResponse
{
    public Guid Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public int TaskStatusId { get; set; }
}