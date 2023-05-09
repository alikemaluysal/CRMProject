using Core.Application.Dtos;

namespace Application.Features.Titles.Queries.GetList;

public class GetListTitleListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}