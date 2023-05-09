using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Enums;

namespace Domain.Entities;

public class UserEmail : Entity<int>
{
    public int? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}