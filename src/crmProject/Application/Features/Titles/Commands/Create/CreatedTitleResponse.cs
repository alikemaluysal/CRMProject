using Core.Application.Responses;

namespace Application.Features.Titles.Commands.Create;

public class CreatedTitleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}