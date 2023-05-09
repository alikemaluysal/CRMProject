using Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserEmails.Commands.Create;

public class CreatedUserEmailResponse : IResponse
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }
}