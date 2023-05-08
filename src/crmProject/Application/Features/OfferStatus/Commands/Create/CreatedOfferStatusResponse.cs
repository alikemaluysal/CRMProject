using Core.Application.Responses;

namespace Application.Features.OfferStatus.Commands.Create;

public class CreatedOfferStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}