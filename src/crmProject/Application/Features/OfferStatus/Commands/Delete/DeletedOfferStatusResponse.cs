using Core.Application.Responses;

namespace Application.Features.OfferStatus.Commands.Delete;

public class DeletedOfferStatusResponse : IResponse
{
    public Guid Id { get; set; }
}