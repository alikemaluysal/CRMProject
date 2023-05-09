using Core.Application.Responses;

namespace Application.Features.OfferStatuses.Commands.Delete;

public class DeletedOfferStatusResponse : IResponse
{
    public int Id { get; set; }
}