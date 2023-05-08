using Core.Application.Responses;

namespace Application.Features.Requests.Commands.Update;

public class UpdatedRequestResponse : IResponse
{
    public Guid Id { get; set; }
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string Description { get; set; }
}