
using Microsoft.AspNetCore.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using StudentBL;

using StudentBL.RequestModel;
using StudentSystemWebApi.Classes;


namespace SoftOneStudentSystemWebApi.Controllers
{

    /*
	 *Author:Buddhika Walpita 
	 * Date:2024-11-12
	 * Description:CRUD Operations in Api
	 */
    [Route("api/[controller]")]
	[ApiController]
	[Log]

	public class StudentApiController : ControllerBase
	{

		//private readonly IStudentService _stuService;
		private readonly IStudentService _stuService;
		private  int rtnValue;

		#region Dependancy Injection
		public StudentApiController(IStudentService  stuService)  //Add DbContext Via Dependancy Injection
        {
			
			this._stuService = stuService;
			

			//this._stuService = new StudentService(new StudentRepo(this.dbContext));


		}
   

        #endregion



        #region Get Data
        [HttpGet]
		public async Task<IActionResult> GetStudents()
		{
			var data=await _stuService.GetStudentsAsync(MyOptions.ConnectionString);
			return Ok(data);
		}

		[HttpGet("{Id:guid}/{StudentCode}")]
		public async Task<IActionResult> GetStudents(Guid Id, string StudentCode)
		{
			var data = await _stuService.GetStudentsAsync(MyOptions.ConnectionString,Id,StudentCode);
			return Ok(data);
		}

		#endregion

		#region Insert/Update Student

		[HttpPost]      //Insert Student 
		
		public async Task<IActionResult> PostStudent(StudentRequest StuRequest)
		{
			try
			{
				rtnValue = await this._stuService.PostStudentAsync(StuRequest, MyOptions.ConnectionString);
				return Ok(rtnValue);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
		#endregion
		#region ErrorHandl
		[ApiExplorerSettings(IgnoreApi = true)]
		[Route("/error-development")]
		public IActionResult HandleErrorDevelopment(
		[FromServices] IHostEnvironment hostEnvironment)
		{
			if (!hostEnvironment.IsDevelopment())
			{
				return NotFound();
			}

			var exceptionHandlerFeature =
				HttpContext.Features.Get<IExceptionHandlerFeature>()!;

			return Problem(
				detail: exceptionHandlerFeature.Error.StackTrace,
				title: exceptionHandlerFeature.Error.Message);
		}
		#endregion
		//[HttpGet("{Id:guid}/{StudentCode}")]
		//public async Task<ActionResult<StudentBL.StudentPersonal>> GetStudents(Guid Id,string StudentCode)  //Get Students via Identififier
		//{
		//	try
		//	{
		//		if (dbContext.StudentPersonals == null)
		//		{
		//			return NotFound();
		//		}
		//		var emp = await dbContext.StudentPersonals.FindAsync(Id,StudentCode);  //check with Student Id
		//		if (emp == null)
		//		{
		//			return NotFound();
		//		}
		//		return emp;
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}
		//#endregion


		//[HttpPut("{Id:guid}/{StudentCode}")]  
		//public async Task<ActionResult<StudentBL.StudentPersonal>> UpdateStudent(Guid Id, string StudentCode, StudentRequest StuRequest)  //Update Students
		//{
		//	if (Id != StuRequest.Id)
		//	{
		//		return BadRequest();
		//	}
		//	using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
		//	{
		//		//dbContext.Entry(StudentRequest).State = EntityState.Modified;
		//		try
		//		{

		//			var stu = await dbContext.StudentPersonals.FindAsync(Id, StudentCode);
		//			if(stu!=null)
		//			{
		//				stu.FirstName = StuRequest.FirstName;
		//				stu.LastName = StuRequest.LastName;
		//				stu.StudentCode = StuRequest.StudentCode;
		//				stu.Email = StuRequest.Email;
		//				stu.Mobile = StuRequest.Mobile;
		//				stu.Nic = StuRequest.NIC;
		//				stu.Address = StuRequest.Address;
		//				stu.Dob= StuRequest.Dob;



		//			}
		//			await dbContext.SaveChangesAsync();
		//			transaction.Commit();
		//			return CreatedAtAction(nameof(GetStudent), new { Id = StuRequest.Id }, StuRequest);

		//		}
		//		catch (DbUpdateConcurrencyException ex)
		//		{
		//			transaction.Rollback();
		//			throw new Exception(ex.Message);
		//		}
		//	}

		//}

		//#endregion

		//#region DeleteStudent
		//[HttpDelete("{Id:guid}/{StudentCode}")]
		//public async Task<ActionResult> DeleteStudent(Guid Id, string StudentCode)  //Delete Student
		//{
		//	try
		//	{
		//		if (dbContext.StudentPersonals == null)
		//		{
		//			return NotFound();
		//		}
		//		var stu = await dbContext.StudentPersonals.FindAsync(Id,StudentCode);
		//		if (stu == null)
		//		{
		//			return NotFound();
		//		}
		//		dbContext.StudentPersonals.Remove(stu);  //Remove the student 
		//		await dbContext.SaveChangesAsync(); //Update the database
		//		return Ok();
		//	}
		//	catch(Exception ex) {
		//		throw new Exception(ex.Message);
		//	}
		//}
		//#endregion
	}
}
