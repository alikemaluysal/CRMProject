using Core.Application.Responses;

namespace Application.Features.RequestStatus.Queries.GetById;

public class GetByIdRequestStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}