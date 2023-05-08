using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class UserAddress : Entity<Guid>
{
    public int UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }
}