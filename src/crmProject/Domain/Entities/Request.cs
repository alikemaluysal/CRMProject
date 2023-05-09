using Core.Persistence.Repositories;
using Core.Security.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Request : Entity<int>
{
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string Description { get; set; }


    #region Navigation Properties

    public virtual RequestStatus RequestStatus { get; set; }

    #endregion
}