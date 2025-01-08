using DataAccessLayer.Repository.Classes;
using DataAccessLayer.Repository.Interfaces;
using StudentBL;
using StudentSystemWebApi;
using StudentSystemWebApi.DataAccessLayer.Models;


namespace SoftOneStudentSystemWebApi.RequestModel
{
    public class StudentService : IStudentService
    {
		private readonly IStudentRepo iStuRepo;
	

		public StudentService()
		{
			
			this.iStuRepo = new StudentRepo(new GitstudentContext());
			
		}

		public async Task<int> DeleteStudentAsync(Guid Id)
		{
			return await this.iStuRepo.DeleteStudent(Id);
		}

		public async Task<List<StudentBL.Classes.StudentPersonal>> GetStudentsAsync()
        {
          var result=  await this.iStuRepo.GetStudents();
            List<StudentBL.Classes.StudentPersonal> stuList = new List<StudentBL.Classes.StudentPersonal>();     
            foreach (var item in result) {
                var stuPer = new StudentBL.Classes.StudentPersonal()
                {
					Id=item.Uid,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    StudentCode = item.StudentCode,
                    Address = item.Address,
                    Email = item.Email,
                    Mobile = item.Mobile,
					NIC = item.Nic,
				   Dob=item.Dob,

                };
                stuList.Add(stuPer);
               
            }
            return stuList;
        }

		public async Task<List<StudentBL.Classes.StudentPersonal>> GetStudentsAsync(Guid Id)
		{
			var result = await this.iStuRepo.GetStudents(Id);
			List<StudentBL.Classes.StudentPersonal> stuList = new List<StudentBL.Classes.StudentPersonal>();
			foreach (var item in result)
			{
				var stuPer = new StudentBL.Classes.StudentPersonal()
				{
					Id = item.Uid,
					FirstName = item.FirstName,
					LastName = item.LastName,
					StudentCode = item.StudentCode,
					Address = item.Address,
					Email = item.Email,
					Mobile = item.Mobile,
					NIC = item.Nic,
					Dob = item.Dob,

				};
				stuList.Add(stuPer);

			}
			return stuList;
		}

		public async Task<List<StudentBL.Classes.StudentPersonal>> GetStudentsAsync(string SearchCriteria)
		{
			var result = await this.iStuRepo.GetStudents(SearchCriteria);
			List<StudentBL.Classes.StudentPersonal> stuList = new List<StudentBL.Classes.StudentPersonal>();
			foreach (var item in result)
			{
				var stuPer = new StudentBL.Classes.StudentPersonal()
				{
					Id = item.Uid,
					FirstName = item.FirstName,
					LastName = item.LastName,
					StudentCode = item.StudentCode,
					Address = item.Address,
					Email = item.Email,
					Mobile = item.Mobile,
					NIC = item.Nic,
					Dob = item.Dob,

				};
				stuList.Add(stuPer);

			}
			return stuList;
		}


		public async Task<int> PostStudentAsync(StudentBL.RequestModel.StudentRequest stuRequest)
        {
			var stuReq = new DataAccessLayer.RequestModel.StudentRequest()
			{
				StudentCode = stuRequest.StudentCode,
				FirstName = stuRequest.FirstName,
				LastName = stuRequest.LastName,
				Mobile = stuRequest.Mobile,
				Email = stuRequest.Email,
				Address = stuRequest.Address,
				Dob = stuRequest.Dob,
				NIC = stuRequest.NIC,
			};

			return await this.iStuRepo.PostStudents(stuReq);

		}

		public async Task<int> PostStudentAsync(Guid Id, StudentBL.RequestModel.StudentRequest stuRequest)
		{
			var stuReq = new DataAccessLayer.RequestModel.StudentRequest()
			{
				StudentCode = stuRequest.StudentCode,
				FirstName = stuRequest.FirstName,
				LastName = stuRequest.LastName,
				Mobile = stuRequest.Mobile,
				Email = stuRequest.Email,
				Address = stuRequest.Address,
				Dob = stuRequest.Dob,
				NIC = stuRequest.NIC,
			};

			return await this.iStuRepo.PostStudents(Id,stuReq);
		}
	}
}
