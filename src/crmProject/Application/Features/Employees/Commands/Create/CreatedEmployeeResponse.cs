using Core.Application.Responses;

namespace Application.Features.Employees.Commands.Create;

public class CreatedEmployeeResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public int? GenderId { get; set; }
    public int? TitleId { get; set; }
    public int? DepartmentId { get; set; }
    public DateTime? StartDate { get; set; }
    public int? StatusTypeId { get; set; }
    public int? RegionId { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? ParentEmployeeId { get; set; }
}