using Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserEmails.Queries.GetById;

public class GetByIdUserEmailResponse : IResponse
{
    public Guid Id { get; set; }
    public int? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }
}