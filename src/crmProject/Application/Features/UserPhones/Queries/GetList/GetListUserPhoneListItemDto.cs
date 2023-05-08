using Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.UserPhones.Queries.GetList;

public class GetListUserPhoneListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }
}