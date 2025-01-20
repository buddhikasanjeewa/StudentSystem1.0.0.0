using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class Table
{
    public Guid Uid { get; set; }

    public string? TableName { get; set; }

    public string? TableDescription { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();
}
