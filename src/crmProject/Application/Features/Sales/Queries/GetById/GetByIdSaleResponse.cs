using Core.Application.Responses;

namespace Application.Features.Sales.Queries.GetById;

public class GetByIdSaleResponse : IResponse
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SaleAmount { get; set; }
    public string Description { get; set; }
}