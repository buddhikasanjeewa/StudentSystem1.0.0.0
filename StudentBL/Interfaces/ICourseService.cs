
using StudentSystemWebApi.DataAccessLayer.RequestModel;
using StudentSystemWebApi.StudentBL.Classes;

namespace StudentSystemWebApi.StudentBL.Interfaces
{
    public interface ICourseService
    {
       
        Task<List<Course>> GetCourseAsync(string ConnectionString, string SearchCriteria);
        Task<List<Course>> GetCourseAsync(string ConnectionString);

       Task<List<Course>> GetCourseAsync(string ConnectionString, Guid Id);
        Task<int> PostCourseAsync(CourseRequest couRequest, string ConnectionString);

        Task<int> PostCourseAsync(Guid Id, CourseRequest couRequest, string ConnectionString);

        public Task<int> DeleteCourseAsync(Guid Id, string ConnectionString);
    }
}
