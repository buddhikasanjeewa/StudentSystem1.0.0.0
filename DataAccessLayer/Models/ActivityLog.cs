﻿using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class ActivityLog
{
    public Guid Uid { get; set; }

    public Guid TableUid { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid CreatedUid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public Guid ModifiedUid { get; set; }

    public virtual User CreatedU { get; set; } = null!;

    public virtual User ModifiedU { get; set; } = null!;

    public virtual Table TableU { get; set; } = null!;
}
