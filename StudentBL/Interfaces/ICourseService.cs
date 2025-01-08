
using StudentSystemWebApi.DataAccessLayer.RequestModel;
using StudentSystemWebApi.StudentBL.Classes;

namespace StudentSystemWebApi.StudentBL.Interfaces
{
    public interface ICourseService
    {
       
        Task<List<Course>> GetCourseAsync(string SearchCriteria);
        Task<List<Course>> GetCourseAsync();

       Task<List<Course>> GetCourseAsync(Guid Id);
        Task<int> PostCourseAsync(CourseRequest couRequest);

        Task<int> PostCourseAsync(Guid Id, CourseRequest couRequest);

        public Task<int> DeleteCourseAsync(Guid Id);
    }
}
