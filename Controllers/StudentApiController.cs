﻿
using Microsoft.AspNetCore.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using StudentBL;

using StudentBL.RequestModel;
using StudentSystemWebApi.Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
			try
			{

				var data = await _stuService.GetStudentsAsync(MyOptions.ConnectionString, Id, StudentCode);
				if (data == null)
				{
					return NotFound();
				}
				return Ok(data);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{SearchCriteria}")]
		public async Task<IActionResult> GetStudents(string SearchCriteria)
		{
			try
			{
				
			   var data = await _stuService.GetStudentsAsync(MyOptions.ConnectionString,SearchCriteria);
				if (data == null)
				{
					return NotFound();
				}
				return Ok(data);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
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
		[HttpPut("{Id:guid}/{StudentCode}")]
		public async Task<IActionResult> UpdateStudent(Guid Id, string StudentCode, StudentRequest StuRequest)
		{
			try
			{
				if (Id != StuRequest.Id)
				{
					return BadRequest();
				}
				rtnValue = await this._stuService.PostStudentAsync(Id,StudentCode,StuRequest, MyOptions.ConnectionString);
				if(rtnValue==0)
				{
					return BadRequest();
				}
				return Ok(rtnValue);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		#endregion
		#region Delete Student
		[HttpDelete("{Id:guid}/{StudentCode}")]
		public async Task<ActionResult> DeleteStudent(Guid Id, string StudentCode)
		{
		   try
			{
				rtnValue= await this._stuService.DeleteStudentAsync(Id, StudentCode, MyOptions.ConnectionString);
				if(rtnValue==0)
				{
					return NotFound();
				}
				return Ok(rtnValue);
			}
	    	catch(Exception ex) {
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
		
	}
}
