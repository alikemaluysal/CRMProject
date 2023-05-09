using Core.Application.Responses;

namespace Application.Features.StatusTypes.Commands.Create;

public class CreatedStatusTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}