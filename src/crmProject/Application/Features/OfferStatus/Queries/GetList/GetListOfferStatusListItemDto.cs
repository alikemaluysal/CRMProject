using Core.Application.Dtos;

namespace Application.Features.OfferStatus.Queries.GetList;

public class GetListOfferStatusListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}