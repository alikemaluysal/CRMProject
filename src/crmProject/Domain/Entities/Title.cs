using System.ComponentModel.DataAnnotations.Schema;
using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Title : Entity<int>
{
    public string Name { get; set; }
}