using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class CourseType
{
    public Guid Uid { get; set; }

    public int CourseTypeId { get; set; }

    public string CourseTypeDescription { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
