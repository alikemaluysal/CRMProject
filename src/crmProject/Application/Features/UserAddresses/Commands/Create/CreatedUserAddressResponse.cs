using Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserAddresses.Commands.Create;

public class CreatedUserAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }
}