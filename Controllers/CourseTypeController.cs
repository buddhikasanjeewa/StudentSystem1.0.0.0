using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentBL.RequestModel;
using StudentSystemWebApi.StudentBL.Interfaces;

namespace StudentSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTypeController : ControllerBase
    {
        private readonly ICourseTypeService _couService;
        private int rtnValue;

        public CourseTypeController(ICourseTypeService couService)
        {
            this._couService = couService;
        }
        // GET: api/<CourseApiController>
        [HttpGet]
        public async Task<IActionResult> GetCourseTypes()
        {
            try
            {
                var data = await _couService.GetCourseTypeAsync();

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
        public async Task<IActionResult> GetCourseTypes(Guid id)
        {
            try
            {

                var data = await _couService.GetCourseTypeAsync(id);

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
        public async Task<IActionResult> GetCourseTypes(string searchCriteria)
        {
            try
            {

                var data = await _couService.GetCourseTypeAsync(searchCriteria);

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
        public async Task<IActionResult> PostCourses([FromBody] CourseTypeRequest stuRequest)
        {
            try
            {
                rtnValue = await this._couService.PostCourseTypeAsync(stuRequest);

                return Ok(rtnValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<CourseApiController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCourses(Guid id, CourseTypeRequest couRequest)
        {
            try
            {
                if (id != couRequest.Uid)
                {
                    return BadRequest();
                }

                rtnValue = await this._couService.PostCourseTypeAsync(id, couRequest);

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
        public async Task<ActionResult> DeleteCoursesTypes(Guid id)
        {
            try
            {
                rtnValue = await this._couService.DeleteCourseTypeAsync(id);

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
