using Core.Application.Dtos;

namespace Application.Features.Requests.Queries.GetList;

public class GetListRequestListItemDto : IDto
{
    public Guid Id { get; set; }
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string Description { get; set; }
}