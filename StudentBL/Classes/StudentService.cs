using DataAccessLayer.Repository.Classes;
using DataAccessLayer.Repository.Interfaces;
using StudentBL;
using StudentSystemWebApi;


namespace SoftOneStudentSystemWebApi.RequestModel
{
    public class StudentService : IStudentService
    {
		private readonly IStudentRepo iStuRepo;
	

		public StudentService()
		{
			
			this.iStuRepo = new StudentRepo(new SoftoneStudentSystemContext());
			
		}

		public async Task<int> DeleteStudentAsync(Guid Id, string ConnectionString)
		{
			return await this.iStuRepo.DeleteStudent(Id, ConnectionString);
		}

		public async Task<List<StudentBL.Classes.StudentPersonal>> GetStudentsAsync(string ConnectionString)
        {
          var result=  await this.iStuRepo.GetStudents(ConnectionString);
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

		public async Task<List<StudentBL.Classes.StudentPersonal>> GetStudentsAsync(string ConnectionString, Guid Id)
		{
			var result = await this.iStuRepo.GetStudents(ConnectionString, Id);
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

		public async Task<List<StudentBL.Classes.StudentPersonal>> GetStudentsAsync(string ConnectionString, string SearchCriteria)
		{
			var result = await this.iStuRepo.GetStudents(ConnectionString, SearchCriteria);
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


		public async Task<int> PostStudentAsync(StudentBL.RequestModel.StudentRequest stuRequest, string ConnectionString)
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

			return await this.iStuRepo.PostStudents(stuReq,ConnectionString);

		}

		public async Task<int> PostStudentAsync(Guid Id, StudentBL.RequestModel.StudentRequest stuRequest, string ConnectionString)
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

			return await this.iStuRepo.PostStudents(Id,stuReq, ConnectionString);
		}
	}
}
