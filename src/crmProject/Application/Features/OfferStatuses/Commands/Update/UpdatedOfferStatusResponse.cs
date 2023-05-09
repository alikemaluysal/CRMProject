using Core.Application.Responses;

namespace Application.Features.OfferStatuses.Commands.Update;

public class UpdatedOfferStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}