using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftOneStudentSystemWebApi.Models;
using SoftOneStudentSystemWebApi.RequestModel;
using System.Net;

namespace SoftOneStudentSystemWebApi.Controllers
{

	/*
	 *Author:Buddhika Walpita 
	 * Date:2024-11-12
	 * Description:CRUD Operations in Api
	 */
	[Route("api/[controller]")]
	[ApiController]
	public class StudentApiController : ControllerBase
	{
		private readonly SoftoneStudentSystemContext dbContext;

		#region Dependancy Injection
		public StudentApiController(SoftoneStudentSystemContext dbContext)  //Add DbContext Via Dependancy Injection
        {
			this.dbContext = dbContext;
		}
		#endregion



		#region Get Data
		[HttpGet]
		public async Task<ActionResult<IEnumerable<StudentPersonal>>> GetStudent() //Get Students All
		{
			try
			{
				if (dbContext.StudentPersonals == null)  //Check Student Null
				{
					return NotFound();
				}
				return await dbContext.StudentPersonals.OrderBy(x=>x.StudentCode).ToListAsync();  //Return  list asyncronusly
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	

		[HttpGet("{Id:guid}/{StudentCode}")]
		public async Task<ActionResult<StudentPersonal>> GetStudents(Guid Id,string StudentCode)  //Get Students via Identififier
		{
			try
			{
				if (dbContext.StudentPersonals == null)
				{
					return NotFound();
				}
				var emp = await dbContext.StudentPersonals.FindAsync(Id,StudentCode);  //check with Student Id
				if (emp == null)
				{
					return NotFound();
				}
				return emp;
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		#endregion
		#region Insert/Update Student
		[HttpPost]      //Insert Student 
			public async Task<ActionResult<StudentPersonal>> PostStudent(StudentRequest StuRequest)
			{
				using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))  //Begin transaction
				{
					try
					{
					var domainModeStudent = new StudentPersonal
					{
						Id = Guid.NewGuid(),
						StudentCode = StuRequest.StudentCode,
						FirstName = StuRequest.FirstName,
						LastName = StuRequest.LastName,
						Mobile = StuRequest.Mobile,
						Email = StuRequest.Email,
						Nic=StuRequest.NIC,
						Dob= StuRequest.Dob,
						Address=StuRequest.Address
					};

					dbContext.StudentPersonals.Add(domainModeStudent);
						await dbContext.SaveChangesAsync();
						transaction.Commit();   //Commit  transaction
					return Ok(domainModeStudent);
					//return CreatedAtAction(nameof(GetStudent), new { Id = StuRequest.Id }, StuRequest); //Redirect to Student get method 
				}
					catch (Exception ex)
					{
						transaction.Rollback();  //Rollback transaction if any exeception 
					throw new Exception(ex.Message);
				}
				}
			}
		

		[HttpPut("{Id:guid}/{StudentCode}")]  
		public async Task<ActionResult<StudentPersonal>> UpdateStudent(Guid Id, string StudentCode, StudentRequest StuRequest)  //Update Students
		{
			if (Id != StuRequest.Id)
			{
				return BadRequest();
			}
			using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
			{
				//dbContext.Entry(StudentRequest).State = EntityState.Modified;
				try
				{

					var stu = await dbContext.StudentPersonals.FindAsync(Id, StudentCode);
					if(stu!=null)
					{
						stu.FirstName = StuRequest.FirstName;
						stu.LastName = StuRequest.LastName;
						stu.StudentCode = StuRequest.StudentCode;
						stu.Email = StuRequest.Email;
						stu.Mobile = StuRequest.Mobile;
						stu.Nic = StuRequest.NIC;
						stu.Address = StuRequest.Address;
						stu.Dob= StuRequest.Dob;



					}
					await dbContext.SaveChangesAsync();
					transaction.Commit();
					return CreatedAtAction(nameof(GetStudent), new { Id = StuRequest.Id }, StuRequest);

				}
				catch (DbUpdateConcurrencyException ex)
				{
					transaction.Rollback();
					throw new Exception(ex.Message);
				}
			}
		
		}

		#endregion

		#region DeleteStudent
		[HttpDelete("{Id:guid}/{StudentCode}")]
		public async Task<ActionResult> DeleteStudent(Guid Id, string StudentCode)  //Delete Student
		{
			try
			{
				if (dbContext.StudentPersonals == null)
				{
					return NotFound();
				}
				var stu = await dbContext.StudentPersonals.FindAsync(Id,StudentCode);
				if (stu == null)
				{
					return NotFound();
				}
				dbContext.StudentPersonals.Remove(stu);  //Remove the student 
				await dbContext.SaveChangesAsync(); //Update the database
				return Ok();
			}
			catch(Exception ex) {
				throw new Exception(ex.Message);
			}
		}
		#endregion
	}
}
