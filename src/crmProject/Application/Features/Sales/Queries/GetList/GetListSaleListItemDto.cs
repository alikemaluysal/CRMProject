using Core.Application.Dtos;

namespace Application.Features.Sales.Queries.GetList;

public class GetListSaleListItemDto : IDto
{
    public Guid Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SaleAmount { get; set; }
    public string Description { get; set; }
}