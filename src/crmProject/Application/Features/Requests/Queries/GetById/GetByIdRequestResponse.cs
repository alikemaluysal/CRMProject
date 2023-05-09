using Core.Application.Responses;

namespace Application.Features.Requests.Queries.GetById;

public class GetByIdRequestResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string Description { get; set; }
}