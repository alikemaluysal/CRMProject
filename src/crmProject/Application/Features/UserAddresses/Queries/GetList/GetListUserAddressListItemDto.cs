using Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.UserAddresses.Queries.GetList;

public class GetListUserAddressListItemDto : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }
}