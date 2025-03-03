using StudentSystemWebApi.DataAccessLayer.Models;
using StudentSystemWebApi.DataAccessLayer.RequestModel;

namespace StudentSystemWebApi.DataAccessLayer.Repository.Interfaces
{
    public interface ICourseTypeRepo
    {
        public Task<List<CourseType>> GetCoursesTypes();
        public Task<List<CourseType>> GetCoursesTypes(string searchCriteria);

        public Task<List<CourseType>> GetCoursesTypes(Guid Id);

        public Task<int> PostCourseTypes(CourseTypeRequest CouRequest);
        public Task<int> PostCourseTypes(Guid Id, CourseTypeRequest CouRequest);
        public Task<int> DeleteCourseTypes(Guid Id);
    }
}
