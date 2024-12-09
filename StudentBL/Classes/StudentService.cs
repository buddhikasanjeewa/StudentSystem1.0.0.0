using Azure.Core;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Classes;
using DataAccessLayer.Repository.Interfaces;
using DataAccessLayer.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StudentBL;
using StudentBL.Classes;
using StudentBL.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftOneStudentSystemWebApi.RequestModel
{
    public class StudentService : IStudentService
    {
		private readonly IStudentRepo iStuRepo;
	

		public StudentService()
		{
			
			this.iStuRepo = new StudentRepo(new SoftoneStudentSystemContext());
			
		}

		public async Task<int> DeleteStudentAsync(Guid Id, string StudentCode, string ConnectionString)
		{
			return await this.iStuRepo.DeleteStudent(Id,StudentCode, ConnectionString);
		}

		public async Task<List<StudentBL.Classes.StudentPersonal>> GetStudentsAsync(string ConnectionString)
        {
          var result=  await this.iStuRepo.GetStudents(ConnectionString);
            List<StudentBL.Classes.StudentPersonal> stuList = new List<StudentBL.Classes.StudentPersonal>();     
            foreach (var item in result) {
                var stuPer = new StudentBL.Classes.StudentPersonal()
                {
					Id=item.Id,
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

		public async Task<List<StudentBL.Classes.StudentPersonal>> GetStudentsAsync(string ConnectionString, Guid Id, string StudentCode)
		{
			var result = await this.iStuRepo.GetStudents(ConnectionString,Id,StudentCode);
			List<StudentBL.Classes.StudentPersonal> stuList = new List<StudentBL.Classes.StudentPersonal>();
			foreach (var item in result)
			{
				var stuPer = new StudentBL.Classes.StudentPersonal()
				{
					Id = item.Id,
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

		public async Task<int> PostStudentAsync(Guid Id, string StudentCode, StudentBL.RequestModel.StudentRequest stuRequest, string ConnectionString)
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

			return await this.iStuRepo.PostStudents(Id,StudentCode,stuReq, ConnectionString);
		}
	}
}
