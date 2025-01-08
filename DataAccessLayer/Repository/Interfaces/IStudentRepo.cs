
using DataAccessLayer.RequestModel;
using StudentSystemWebApi.DataAccessLayer.Models;


namespace DataAccessLayer.Repository.Interfaces
{
    public interface IStudentRepo
    {

    
        public Task<List<StudentPersonal>> GetStudents();
		public Task<List<StudentPersonal>> GetStudents(string searchCriteria);

		public Task<List<StudentPersonal>> GetStudents(Guid Id);

		public Task<int> PostStudents(StudentRequest StuRequest);
		public Task<int> PostStudents(Guid Id,StudentRequest StuRequest);
		public Task<int> DeleteStudent(Guid Id);

	}
}
