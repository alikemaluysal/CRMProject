using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Setting : Entity<int>
{
    public int UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }


    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}