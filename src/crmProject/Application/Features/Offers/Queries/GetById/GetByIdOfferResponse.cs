using Core.Application.Responses;

namespace Application.Features.Offers.Queries.GetById;

public class GetByIdOfferResponse : IResponse
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public int OfferStatusId { get; set; }
}