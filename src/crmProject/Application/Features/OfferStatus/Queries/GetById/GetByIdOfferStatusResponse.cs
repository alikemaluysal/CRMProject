using Core.Application.Responses;

namespace Application.Features.OfferStatus.Queries.GetById;

public class GetByIdOfferStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}