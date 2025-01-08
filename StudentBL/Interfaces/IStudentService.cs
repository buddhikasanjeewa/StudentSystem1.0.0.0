
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

		Task<List<StudentPersonal>> GetStudentsAsync();
		Task<List<StudentPersonal>> GetStudentsAsync(string SearchCriteria);

		Task<List<StudentPersonal>> GetStudentsAsync(Guid Id);
		Task<int> PostStudentAsync(StudentRequest stuRequest);

		Task<int> PostStudentAsync(Guid Id, StudentRequest stuRequest);

		public Task<int> DeleteStudentAsync(Guid Id);



	}
}
