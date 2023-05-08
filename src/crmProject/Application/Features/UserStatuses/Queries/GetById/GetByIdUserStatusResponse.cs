using Core.Application.Responses;

namespace Application.Features.UserStatuses.Queries.GetById;

public class GetByIdUserStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}