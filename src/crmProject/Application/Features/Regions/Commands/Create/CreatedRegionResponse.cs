using Core.Application.Responses;

namespace Application.Features.Regions.Commands.Create;

public class CreatedRegionResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
}