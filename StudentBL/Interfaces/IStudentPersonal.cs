using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL.Interfaces
{
    public interface IStudentPersonal
    {
        [Key]
        public Guid Id { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public string? Address { get; set; }
    }
}
