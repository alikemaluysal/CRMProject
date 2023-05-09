using Core.Application.Dtos;

namespace Application.Features.TaskEntities.Queries.GetList;

public class GetListTaskEntityListItemDto : IDto
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public int TaskStatusId { get; set; }
}