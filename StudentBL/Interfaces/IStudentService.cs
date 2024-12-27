
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentBL.Classes;
using StudentBL.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL
{
    public interface IStudentService
	{
		////void GetStudentWithId(int id);

		Task<List<StudentPersonal>> GetStudentsAsync(string ConnectionString);
		Task<List<StudentPersonal>> GetStudentsAsync(string ConnectionString, string SearchCriteria);

		Task<List<StudentPersonal>> GetStudentsAsync(string ConnectionString, Guid Id);
		Task<int> PostStudentAsync(StudentRequest stuRequest, string ConnectionString);

		Task<int> PostStudentAsync(Guid Id, StudentRequest stuRequest, string ConnectionString);

		public Task<int> DeleteStudentAsync(Guid Id, string ConnectionString);



		//void GetStudentsWithSearch(string serachCriteria);

		//void PostStudent(StudentRequest stuRequest);
		//void DeleteStudent(int id);
	}
}
