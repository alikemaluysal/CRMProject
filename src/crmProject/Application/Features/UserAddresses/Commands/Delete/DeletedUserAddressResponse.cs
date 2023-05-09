using Core.Application.Responses;

namespace Application.Features.UserAddresses.Commands.Delete;

public class DeletedUserAddressResponse : IResponse
{
    public int Id { get; set; }
}