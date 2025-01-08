using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class CourseType
{
    public Guid Uid { get; set; }

    public string CourseTypeId { get; set; } = null!;

    public string CourseTypeDescription { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
