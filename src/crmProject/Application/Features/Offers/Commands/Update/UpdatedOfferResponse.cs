using Core.Application.Responses;

namespace Application.Features.Offers.Commands.Update;

public class UpdatedOfferResponse : IResponse
{
    public Guid Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public int OfferStatusId { get; set; }
}