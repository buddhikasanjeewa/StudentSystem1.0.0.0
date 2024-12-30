using StudentSystemWebApi.DataAccessLayer.Models;
using StudentSystemWebApi.DataAccessLayer.RequestModel;

namespace StudentSystemWebApi.DataAccessLayer.Repository.Interfaces
{
    public interface ICourseRepo
    {

        public Task<List<Course>> GetCourses(string constr);
        public Task<List<Course>> GetCourses(string constr, string searchCriteria);



        public Task<int> PostCourses(CourseRequest CouRequest, string constr);
        public Task<int> PostCourses(Guid Id, CourseRequest CouRequest, string constr);
        public Task<int> DeleteCourses(Guid Id, string constr);
    }
}
