using Core.Application.Responses;

namespace Application.Features.Titles.Commands.Update;

public class UpdatedTitleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}