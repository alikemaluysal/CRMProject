using Core.Application.Responses;

namespace Application.Features.StatusTypes.Queries.GetById;

public class GetByIdStatusTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}