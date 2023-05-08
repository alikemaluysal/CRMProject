using Core.Application.Dtos;

namespace Application.Features.Regions.Queries.GetList;

public class GetListRegionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
}