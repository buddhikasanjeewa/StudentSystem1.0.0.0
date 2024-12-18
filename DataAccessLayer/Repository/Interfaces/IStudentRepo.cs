using DataAccessLayer.Models;
using DataAccessLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interfaces
{
    public interface IStudentRepo
    {

    
        public Task<List<StudentPersonal>> GetStudents(string constr);
		public Task<List<StudentPersonal>> GetStudents(string constr, string searchCriteria);

		public Task<List<StudentPersonal>> GetStudents(string constr, Guid Id, string StudentCode);

		public Task<int> PostStudents(StudentRequest StuRequest, string constr);
		public Task<int> PostStudents(Guid Id, string StudentCode,StudentRequest StuRequest, string constr);
		public Task<int> DeleteStudent(Guid Id, string StudentCode ,string constr);

	}
}
