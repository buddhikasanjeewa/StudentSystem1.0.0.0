
using DataAccessLayer.RequestModel;
using StudentSystemWebApi.DataAccessLayer.Models;


namespace DataAccessLayer.Repository.Interfaces
{
    public interface IStudentRepo
    {

    
        public Task<List<StudentPersonal>> GetStudents(string constr);
		public Task<List<StudentPersonal>> GetStudents(string constr, string searchCriteria);

		public Task<List<StudentPersonal>> GetStudents(string constr, Guid Id);

		public Task<int> PostStudents(StudentRequest StuRequest, string constr);
		public Task<int> PostStudents(Guid Id,StudentRequest StuRequest, string constr);
		public Task<int> DeleteStudent(Guid Id ,string constr);

	}
}
