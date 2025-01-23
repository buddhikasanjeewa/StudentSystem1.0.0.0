using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var data = await _couService.GetCourseAsync();

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetCourses(Guid id)
        {
            try
            {

                var data = await _couService.GetCourseAsync(id);

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }

        [HttpGet("{SearchCriteria}")]
        public async Task<IActionResult> GetCourses(string searchCriteria)
        {
            try
            {

                var data = await _couService.GetCourseAsync(searchCriteria);

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST api/<CourseApiController>
        [HttpPost]
        public async Task<IActionResult> PostCourses([FromBody] CourseRequest stuRequest)
        {
            try
            {
                rtnValue = await this._couService.PostCourseAsync(stuRequest);

                return Ok(rtnValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<CourseApiController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCourses(Guid id, CourseRequest couRequest)
        {
            try
            {
                if (id != couRequest.Id)
                {
                    return BadRequest();
                }

                rtnValue = await this._couService.PostCourseAsync(id, couRequest);

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
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCourses(Guid id)
        {
            try
            {
                rtnValue = await this._couService.DeleteCourseAsync(id);

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
