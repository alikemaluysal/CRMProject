using Core.Application.Responses;

namespace Application.Features.StatusTypes.Commands.Update;

public class UpdatedStatusTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}