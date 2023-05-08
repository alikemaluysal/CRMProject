using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class UserEmail : Entity<Guid>
{
    public int? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }
}