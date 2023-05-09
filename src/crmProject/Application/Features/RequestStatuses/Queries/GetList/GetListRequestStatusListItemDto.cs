using Core.Application.Dtos;

namespace Application.Features.RequestStatuses.Queries.GetList;

public class GetListRequestStatusListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}