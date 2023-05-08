using System.ComponentModel.DataAnnotations.Schema;
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Title : Entity<Guid>
{
    public string Name { get; set; }
}