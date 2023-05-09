using Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.UserEmails.Queries.GetList;

public class GetListUserEmailListItemDto : IDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }
}