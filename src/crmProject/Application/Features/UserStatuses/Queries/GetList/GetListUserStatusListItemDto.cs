using Core.Application.Dtos;

namespace Application.Features.UserStatuses.Queries.GetList;

public class GetListUserStatusListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}