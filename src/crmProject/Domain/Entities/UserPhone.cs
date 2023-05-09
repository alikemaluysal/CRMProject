using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Enums;

namespace Domain.Entities;

public class UserPhone : Entity<int>
{
    public int UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}