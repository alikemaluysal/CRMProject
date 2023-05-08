using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class UserPhone : Entity<Guid>
{
    public int UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }
}