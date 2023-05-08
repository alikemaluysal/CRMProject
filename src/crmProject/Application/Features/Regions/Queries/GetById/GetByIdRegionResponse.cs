using Core.Application.Responses;

namespace Application.Features.Regions.Queries.GetById;

public class GetByIdRegionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
}