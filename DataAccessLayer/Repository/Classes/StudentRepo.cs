
using DataAccessLayer.Repository.Interfaces;
using DataAccessLayer.RequestModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentSystemWebApi;
using StudentSystemWebApi.DataAccessLayer.Models;

namespace DataAccessLayer.Repository.Classes
{
	public class StudentRepo : IStudentRepo
	{
		private readonly SoftoneStudentSystemContext dbContext;
		public string ConnectionString { get; set; }

		private int retunVal;
		public StudentRepo(SoftoneStudentSystemContext dbContext)
		{
			this.dbContext = dbContext;  
		}



		public async Task<List<StudentPersonal>> GetStudents(string  constr)
		{
			Initalize(constr);
			if (dbContext.StudentPersonals == null)  //Check Student Null
			{
				throw new Exception("Not Found");
			}
		
			var paramSearchCri = new SqlParameter("@SeachCriteria", "");
			var paramType = new SqlParameter("@type", 1);
			var students = await this.dbContext.StudentPersonals
					  .FromSqlRaw("Get_StudentData @SeachCriteria,@type", paramSearchCri, paramType)
					  .ToListAsync();
			return students;
			//	return await dbContext.StudentPersonals.ToListAsync();
		}

		public async Task<List<StudentPersonal>> GetStudents(string constr, Guid Id)
		{
			try
			{
				Initalize(constr);
				var result = dbContext.StudentPersonals.Where(x => x.Uid == Id );
				if (result.Any())
				{
					return await result.ToListAsync();
				}
				else
				{
					throw new Exception("No data found");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<StudentPersonal>> GetStudents(string constr, string searchCriteria)
		{
			try
			{
				Initalize(constr);
				//var result = dbContext.StudentPersonals.Where(x => x.Id == Id && x.StudentCode == StudentCode);

				var paramSearchCri = new SqlParameter("@SeachCriteria",searchCriteria );
				var paramType = new SqlParameter("@type", 2);
				var result = await this.dbContext.StudentPersonals
						   .FromSqlRaw("Get_StudentData @SeachCriteria,@type", paramSearchCri, paramType).ToListAsync();


				if (result.Any())
				{
					return result;
				}
				else
				{
					throw new Exception("No data found");
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private void Initalize(string constr)
		{
			this.dbContext.ConnectionString = constr;
		}

		public async Task<int> PostStudents(StudentRequest StuRequest, string constr)
		{
			Initalize(constr);
			using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))  //Begin transaction
			{
				try
				{
					//var domainModeStudent = new StudentPersonal
					//{
					//	Id = Guid.NewGuid(),
					//	StudentCode = StuRequest.StudentCode,
					//	FirstName = StuRequest.FirstName,
					//	LastName = StuRequest.LastName,
					//	Mobile = StuRequest.Mobile,
					//	Email = StuRequest.Email,
					//	Nic = StuRequest.NIC,
					//	Dob = StuRequest.Dob,
					//	Address = StuRequest.Address
					//};
					var paramList = new List<SqlParameter>()
					{
					   new SqlParameter("@Id", Guid.NewGuid()),
					   new SqlParameter("@StudentCode", StuRequest.StudentCode),
					   new SqlParameter("@FirstName", StuRequest.FirstName),
					   new SqlParameter("@LastName", StuRequest.LastName),
					   new SqlParameter("@Address", StuRequest.Address),
					   new SqlParameter("@mobile", StuRequest.Mobile),
					   new SqlParameter("@email", StuRequest.Email),
					   new SqlParameter("@DOB",StuRequest.Dob),
					   new SqlParameter("@NIC", StuRequest.NIC)
					
					};
					//paramList[7].Value = StuRequest.Dob.Value.ToShortDateString();
					//var paramGuid = new SqlParameter("@Id", Guid.NewGuid());
					//var paramStuCode = new SqlParameter("@StudentCode", StuRequest.StudentCode);
					//var paramFName = new SqlParameter("@FirstName", StuRequest.FirstName);
					//var paramLName = new SqlParameter("@LastName", StuRequest.LastName);
					//var paramAdd = new SqlParameter("@Address", StuRequest.Address);
					//var paramMobile = new SqlParameter("@mobile", StuRequest.Mobile);
					//var paramEmail = new SqlParameter("@email", StuRequest.Email);
					//var paramDob = new SqlParameter("@DOB", StuRequest.Dob);
					//var paramType = new SqlParameter("@NIC", StuRequest.NIC);

					//var result = await Task.Run(() => _dbContext.Database
				 //  .ExecuteSqlRawAsync(@"exec AddNewProduct @ProductName, @ProductDescription, @ProductPrice, @ProductStock", parameter.ToArray()));

					var result = await Task.Run(() => dbContext.Database
										   .ExecuteSqlRawAsync(@"exec Save_Student @Id,@StudentCode,@FirstName,@LastName,@Address,@mobile,@email,@DOB,@NIC", paramList.ToArray()));

					//	dbContext.StudentPersonals.Add(domainModeStudent);
					//await dbContext.SaveChangesAsync();
					transaction.Commit();   //Commit  transaction
					retunVal = 1;
					return retunVal;
					//return CreatedAtAction(nameof(GetStudent), new { Id = StuRequest.Id }, StuRequest); //Redirect to Student get method 
				}
				catch (Exception ex)
				{
					transaction.Rollback();  //Rollback transaction if any exeception 

					throw new Exception(ex.Message);
				}
			}
		}

		public async Task<int> PostStudents(Guid Id, StudentRequest StuRequest, string constr)
		{

			Initalize(constr);
			using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))  //Begin transaction
			{
				try
				{

					var stu = await dbContext.StudentPersonals.FindAsync(Id);
					if (stu != null)
					{
						stu.FirstName = StuRequest.FirstName;
						stu.LastName = StuRequest.LastName;
						stu.StudentCode = StuRequest.StudentCode;
						stu.Email = StuRequest.Email;
						stu.Mobile = StuRequest.Mobile;
						stu.Nic = StuRequest.NIC;
						stu.Address = StuRequest.Address;
						stu.Dob = StuRequest.Dob;

					}
					await dbContext.SaveChangesAsync();
					transaction.Commit();
					retunVal = 1;
					return retunVal;

				}
				catch (Exception ex)
				{
					transaction.Rollback();  //Rollback transaction if any exeception 

					throw new Exception(ex.Message);
				}
			}
		}

		public async Task<int> DeleteStudent(Guid Id, string constr)
		{
			try
			{
				Initalize(constr);
				var stu = await dbContext.StudentPersonals.FindAsync(Id);
			
				dbContext.StudentPersonals.Remove(stu);  //Remove the student 
				await dbContext.SaveChangesAsync(); //Update the database
				retunVal = 1;

				return retunVal;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
