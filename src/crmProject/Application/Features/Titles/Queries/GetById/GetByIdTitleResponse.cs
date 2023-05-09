using Core.Application.Responses;

namespace Application.Features.Titles.Queries.GetById;

public class GetByIdTitleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}