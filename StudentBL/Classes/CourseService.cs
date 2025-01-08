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
        public async Task<int> DeleteCourseAsync(Guid Id)
        {
            return await this.iCouRepo.DeleteCourses(Id);
        }


       public async Task<List<Course>> GetCourseAsync()
        {
            var result = await this.iCouRepo.GetCourses();
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
        public async Task<List<Course>> GetCourseAsync(Guid Id)
        {
            var result = await this.iCouRepo.GetCourses(Id);
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

      

        public async Task<List<Course>> GetCourseAsync(string SearchCriteria)
        {
            var result = await this.iCouRepo.GetCourses(SearchCriteria);
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

      

        public async Task<int> PostCourseAsync(CourseRequest couRequest)
        {
            var couReq = new DataAccessLayer.RequestModel.CourseRequest()
            {
              
                Id= couRequest.Id,
                CourseTypeUID = couRequest.CourseTypeUID,
                CourseCode=couRequest.CourseCode,
                CourseDescription = couRequest.CourseDescription,
            };

            return await this.iCouRepo.PostCourses(couReq);
        }

        public async Task<int> PostCourseAsync(Guid Id, CourseRequest couRequest)
        {
            var couReq = new DataAccessLayer.RequestModel.CourseRequest()
            {
                Id = couRequest.Id,
                CourseTypeUID = couRequest.CourseTypeUID,
                CourseCode = couRequest.CourseCode,
                CourseDescription = couRequest.CourseDescription,
            };

            return await this.iCouRepo.PostCourses(Id, couReq);
        }

       
    }
}
