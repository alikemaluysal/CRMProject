using Core.Application.Responses;

namespace Application.Features.OfferStatuses.Commands.Create;

public class CreatedOfferStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}