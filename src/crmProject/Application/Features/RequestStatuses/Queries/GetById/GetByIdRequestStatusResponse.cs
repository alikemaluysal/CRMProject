using Core.Application.Responses;

namespace Application.Features.RequestStatuses.Queries.GetById;

public class GetByIdRequestStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}