using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoftOneStudentSystemWebApi.Models;

public partial class StudentPersonal
{

    //[JsonIgnore]
    public Guid Id { get; set; }

    public string StudentCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
	//[JsonIgnore]
	public string? Address { get; set; }

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;
	//[JsonIgnore]
	public DateTime? Dob { get; set; }
	
	public string Nic { get; set; } = null!;
}
