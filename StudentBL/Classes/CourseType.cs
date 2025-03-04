using StudentSystemWebApi.StudentBL.Interfaces;
using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.StudentBL.Classes;

public partial class CourseType: ICourseType
{
    public Guid Uid { get; set; }

    public string CourseTypeId { get; set; } = null!;

    public string CourseTypeName { get; set; } = null!;
    public string CourseTypeDescription { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
