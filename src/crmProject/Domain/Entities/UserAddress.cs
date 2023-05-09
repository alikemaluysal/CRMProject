using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Enums;

namespace Domain.Entities;

public class UserAddress : Entity<int>
{
    public int UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}