using System;
using System.Collections.Generic;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class StudentPersonal
{
    public Guid Uid { get; set; }

    public string StudentCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string Nic { get; set; } = null!;

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
