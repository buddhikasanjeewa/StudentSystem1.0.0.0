using StudentBL.RequestModel;
using StudentSystemWebApi.StudentBL.Classes;

namespace StudentSystemWebApi.StudentBL.Interfaces
{
    public interface ICourseTypeService
    {

        Task<List<CourseType>> GetCourseTypeAsync(string SearchCriteria);
        Task<List<CourseType>> GetCourseTypeAsync();

         Task<List<CourseType>> GetCourseTypeAsync(Guid Id);
        Task<int> PostCourseTypeAsync(CourseTypeRequest couRequest);

        Task<int> PostCourseTypeAsync(Guid Id, CourseTypeRequest couRequest);

        Task<int> DeleteCourseTypeAsync(Guid Id);
    }
}
