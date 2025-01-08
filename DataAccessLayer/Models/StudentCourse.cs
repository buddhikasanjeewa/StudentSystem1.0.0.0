using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class StudentCourse
{
    public Guid Uid { get; set; }

    public Guid StudentUid { get; set; }

    public Guid CourseUid { get; set; }

    public virtual Course CourseU { get; set; } = null!;

    public virtual StudentPersonal StudentU { get; set; } = null!;
}
