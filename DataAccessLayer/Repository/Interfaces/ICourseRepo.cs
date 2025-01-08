using StudentSystemWebApi.DataAccessLayer.Models;
using StudentSystemWebApi.DataAccessLayer.RequestModel;

namespace StudentSystemWebApi.DataAccessLayer.Repository.Interfaces
{
    public interface ICourseRepo
    {

        public Task<List<Course>> GetCourses();
        public Task<List<Course>> GetCourses(string searchCriteria);

        public Task<List<Course>> GetCourses(Guid Id);

        public Task<int> PostCourses(CourseRequest CouRequest);
        public Task<int> PostCourses(Guid Id, CourseRequest CouRequest);
        public Task<int> DeleteCourses(Guid Id);
    }
}
