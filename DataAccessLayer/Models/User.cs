using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class User
{
    public Guid Uid { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogCreatedUs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<ActivityLog> ActivityLogModifiedUs { get; set; } = new List<ActivityLog>();
}
