
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentBL;
using StudentSystemWebApi.Classes;
using StudentBL.RequestModel;

namespace StudentSystemWebApi.Controllers
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

		private readonly IStudentService _stuService;
		private  int rtnValue;

		#region Dependancy Injection
		public StudentApiController(IStudentService  stuService)  //Add DbContext Via Dependancy Injection
        {		
			this._stuService = stuService;
		}
        #endregion

        #region Get Data
        [HttpGet]
		public async Task<IActionResult> GetStudents()
		{
			try
			{
				var data = await _stuService.GetStudentsAsync();

				if (data == null)
				{
					return NotFound();
				}

				if (data.Count == 0)
				{
					return NoContent();
				}

				return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetStudents(Guid id)
		{
			try
			{

				var data = await _stuService.GetStudentsAsync(id);

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

		[HttpGet("{searchCriteria}")]
		public async Task<IActionResult> GetStudents(string searchCriteria)
		{
			try
			{
				
			   var data = await _stuService.GetStudentsAsync(searchCriteria);

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
		
		public async Task<IActionResult> PostStudent(StudentRequest stuRequest)
		{
			try
			{
				rtnValue = await this._stuService.PostStudentAsync(stuRequest);
				return Ok(rtnValue);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateStudent(Guid id, StudentRequest stuRequest)
		{
			try
			{
				if (id != stuRequest.Id)
				{
					return BadRequest();
				}

				rtnValue = await this._stuService.PostStudentAsync(id,stuRequest);

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
		[HttpDelete("{id:guid}")]
		public async Task<ActionResult> DeleteStudent(Guid id)
		{
		   try
			{
				rtnValue= await this._stuService.DeleteStudentAsync(id);

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

		#region ErrorHandle
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
