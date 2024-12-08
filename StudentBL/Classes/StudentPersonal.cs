using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL.Classes
{
    public class StudentPersonal
    {
        [Key]
        public Guid Id { get; set; }
        public required string StudentCode { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Mobile { get; set; }
        public string? Email { get; set; }
        public required string NIC { get; set; }
        public string? Address { get; set; }

		public DateTime? Dob { get; set; }
	}
}

