using Core.Application.Responses;

namespace Application.Features.UserPhones.Commands.Delete;

public class DeletedUserPhoneResponse : IResponse
{
    public int Id { get; set; }
}