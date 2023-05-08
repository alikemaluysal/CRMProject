using Core.Application.Responses;

namespace Application.Features.OfferStatus.Commands.Update;

public class UpdatedOfferStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}