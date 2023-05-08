using Core.Application.Dtos;

namespace Application.Features.RequestStatus.Queries.GetList;

public class GetListRequestStatusListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}