using DataAccessLayer.Repository.Classes;
using DataAccessLayer.Repository.Interfaces;
using NuGet.Protocol.Plugins;
using StudentSystemWebApi.DataAccessLayer.Models;
using StudentSystemWebApi.DataAccessLayer.Repository.Classes;
using StudentSystemWebApi.DataAccessLayer.Repository.Interfaces;
using StudentSystemWebApi.DataAccessLayer.RequestModel;
using StudentSystemWebApi.StudentBL.Interfaces;

namespace StudentSystemWebApi.StudentBL.Classes
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo iCouRepo;
        public CourseService()
        {

            this.iCouRepo = new CourseRepo(new GitstudentContext());

        }
        public async Task<int> DeleteCourseAsync(Guid Id, string ConnectionString)
        {
            return await this.iCouRepo.DeleteCourses(Id, ConnectionString);
        }


       public async Task<List<Course>> GetCourseAsync(string ConnectionString)
        {
            var result = await this.iCouRepo.GetCourses(ConnectionString);
            List<StudentBL.Classes.Course> couList = new List<StudentBL.Classes.Course>();
            foreach (var item in result)
            {

                var couPer = new StudentBL.Classes.Course()
                {
                    UID = item.Uid,
                    CoureTypeUid = item.CourseTypeUid,
                    CourseCode = item.CourseCode,
                    Course_Description = item.CourseDescription,

                };
                couList.Add(couPer);

            }
            return couList;
        }
        public async Task<List<Course>> GetCourseAsync(string ConnectionString, Guid Id)
        {
            var result = await this.iCouRepo.GetCourses(ConnectionString,Id);
            List<StudentBL.Classes.Course> couList = new List<StudentBL.Classes.Course>();
            foreach (var item in result)
            {

                var couPer = new StudentBL.Classes.Course()
                {
                   UID=item.Uid,
                   CoureTypeUid=item.CourseTypeUid,
                   CourseCode=item.CourseCode,
                   Course_Description=item.CourseDescription,

                };
                couList.Add(couPer);

            }
            return couList;
        }

      

        public async Task<List<Course>> GetCourseAsync(string ConnectionString, string SearchCriteria)
        {
            var result = await this.iCouRepo.GetCourses(ConnectionString, SearchCriteria);
            List<StudentBL.Classes.Course> couList = new List<StudentBL.Classes.Course>();
            foreach (var item in result)
            {
                var couPer = new StudentBL.Classes.Course()
                {
                    UID = item.Uid,
                    CoureTypeUid = item.CourseTypeUid,
                    CourseCode = item.CourseCode,
                    Course_Description = item.CourseDescription,

                };
                couList.Add(couPer);

            }
            return couList;
        }

      

        public async Task<int> PostCourseAsync(CourseRequest couRequest, string ConnectionString)
        {
            var couReq = new DataAccessLayer.RequestModel.CourseRequest()
            {
              
                Id= couRequest.Id,
                CourseTypeUID = couRequest.CourseTypeUID,
                CourseCode=couRequest.CourseCode,
                CourseDescription = couRequest.CourseDescription,
            };

            return await this.iCouRepo.PostCourses(couReq, ConnectionString);
        }

        public async Task<int> PostCourseAsync(Guid Id, CourseRequest couRequest, string ConnectionString)
        {
            var couReq = new DataAccessLayer.RequestModel.CourseRequest()
            {
                Id = couRequest.Id,
                CourseTypeUID = couRequest.CourseTypeUID,
                CourseCode = couRequest.CourseCode,
                CourseDescription = couRequest.CourseDescription,
            };

            return await this.iCouRepo.PostCourses(Id, couReq, ConnectionString);
        }

       
    }
}
