using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class Course
{
    public Guid Uid { get; set; }

    public string CourseCode { get; set; } = null!;

    public Guid CourseTypeUid { get; set; }

    public string CourseDescription { get; set; } = null!;

    public virtual CourseType CourseTypeU { get; set; } = null!;

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
