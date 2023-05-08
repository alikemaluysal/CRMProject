using Core.Application.Dtos;

namespace Application.Features.Offers.Queries.GetList;

public class GetListOfferListItemDto : IDto
{
    public Guid Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public int OfferStatusId { get; set; }
}