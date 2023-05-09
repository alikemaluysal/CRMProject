using Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserPhones.Commands.Create;

public class CreatedUserPhoneResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }
}