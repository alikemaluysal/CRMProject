using Core.Application.Responses;

namespace Application.Features.Regions.Commands.Update;

public class UpdatedRegionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
}