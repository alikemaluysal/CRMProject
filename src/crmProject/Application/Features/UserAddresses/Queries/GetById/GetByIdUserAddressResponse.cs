using Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserAddresses.Queries.GetById;

public class GetByIdUserAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }
}