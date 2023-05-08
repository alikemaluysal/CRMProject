using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Setting : Entity<Guid>
{
    public int UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }
}