using Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserAddresses.Commands.Update;

public class UpdatedUserAddressResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }
}