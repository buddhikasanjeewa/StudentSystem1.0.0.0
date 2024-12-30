using Microsoft.AspNetCore.Mvc;
using StudentBL;
using StudentSystemWebApi.DataAccessLayer.RequestModel;
using StudentSystemWebApi.StudentBL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApiController : ControllerBase
    {

        private readonly ICourseService _couService;
        private int rtnValue;
        public CourseApiController(ICourseService couService)
        {
            this._couService = couService;
        }
        // GET: api/<CourseApiController>
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var data = await _couService.GetCourseAsync(MyOptions.ConnectionString);
            return Ok(data);
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetCourses(Guid Id)
        {
            try
            {

                var data = await _couService.GetCourseAsync(MyOptions.ConnectionString, Id);
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
        public async Task<IActionResult> GetCourses(string SearchCriteria)
        {
            try
            {

                var data = await _couService.GetCourseAsync(MyOptions.ConnectionString, SearchCriteria);
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

        // POST api/<CourseApiController>
        [HttpPost]
        public async Task<IActionResult> PostCourses([FromBody] CourseRequest StuRequest)
        {
            try
            {
                rtnValue = await this._couService.PostCourseAsync(StuRequest, MyOptions.ConnectionString);
                return Ok(rtnValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<CourseApiController>/5
        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> UpdateStude(Guid Id, CourseRequest CouRequest)
        {
            try
            {
                if (Id != CouRequest.Id)
                {
                    return BadRequest();
                }
                rtnValue = await this._couService.PostCourseAsync(Id, CouRequest, MyOptions.ConnectionString);
                if (rtnValue == 0)
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
        [HttpDelete("{Id:guid}")]
        public async Task<ActionResult> DeleteCourses(Guid Id)
        {
            try
            {
                rtnValue = await this._couService.DeleteCourseAsync(Id, MyOptions.ConnectionString);
                if (rtnValue == 0)
                {
                    return NotFound();
                }
                return Ok(rtnValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
