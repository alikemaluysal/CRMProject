using Core.Application.Dtos;

namespace Application.Features.OfferStatuses.Queries.GetList;

public class GetListOfferStatusListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}