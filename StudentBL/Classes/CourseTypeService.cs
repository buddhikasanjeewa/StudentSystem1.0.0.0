using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using StudentBL.RequestModel;
using StudentSystemWebApi.DataAccessLayer.Models;
using StudentSystemWebApi.DataAccessLayer.Repository.Classes;
using StudentSystemWebApi.StudentBL.Interfaces;

namespace StudentSystemWebApi.StudentBL.Classes
{
    public class CourseTypeService : ICourseTypeService
    {
        private readonly GitstudentContext context;
        private CourseTypeRepo iCouRepo;

        public CourseTypeService(GitstudentContext context)
        {
            this.iCouRepo = new CourseTypeRepo(new GitstudentContext());
        }
        public async Task<int> DeleteCourseTypeAsync(Guid Id)
        {
            return await this.iCouRepo.DeleteCourseTypes(Id);
        }

        public async Task<List<CourseType>> GetCourseTypeAsync()
        {
            var result = await this.iCouRepo.GetCoursesTypes();
            List<StudentBL.Classes.CourseType> couList = new List<StudentBL.Classes.CourseType>();
            foreach (var item in result)
            {

                var couPer = new StudentBL.Classes.CourseType()
                {
                    Uid= item.Uid,
                    CourseTypeDescription = item.CourseTypeDescription,
                    CourseTypeId =item.CourseTypeId

                    

                };
                couList.Add(couPer);

            }
            return couList;
        }

        public async Task<List<CourseType>> GetCourseTypeAsync(Guid Id)
        {
            var result = await this.iCouRepo.GetCoursesTypes(Id);
            List<StudentBL.Classes.CourseType> couList = new List<StudentBL.Classes.CourseType>();
            foreach (var item in result)
            {

                var couPer = new StudentBL.Classes.CourseType()
                {
                    Uid = item.Uid,
                    CourseTypeDescription = item.CourseTypeDescription,
                    CourseTypeId = item.CourseTypeId

                };
                couList.Add(couPer);

            }
            return couList;
        }

        public async Task<List<CourseType>> GetCourseTypeAsync(string SearchCriteria)
        {
            var result = await this.iCouRepo.GetCoursesTypes(SearchCriteria);
            List<StudentBL.Classes.CourseType> couList = new List<StudentBL.Classes.CourseType>();
            foreach (var item in result)
            {
                var couPer = new StudentBL.Classes.CourseType()
                {
                    Uid = item.Uid,
                    CourseTypeDescription = item.CourseTypeDescription,
                    CourseTypeId = item.CourseTypeId

                };
                couList.Add(couPer);

            }
            return couList;
        }

        public async Task<int> PostCourseTypeAsync(CourseTypeRequest couRequest)
        {
            var couReq = new DataAccessLayer.RequestModel.CourseTypeRequest()
            {
                Uid= couRequest.Uid,
                CourseTypeId= couRequest.CourseTypeId,
                CourseTypeDescription=couRequest.CourseTypeDescription
              
         
            };

            return await this.iCouRepo.PostCourseTypes(couReq);
        }

        public async Task<int> PostCourseTypeAsync(Guid Id, CourseTypeRequest couRequest)
        {
            var couReq = new DataAccessLayer.RequestModel.CourseTypeRequest()
            {
                Uid = couRequest.Uid,
                CourseTypeId = couRequest.CourseTypeId,
                CourseTypeDescription = couRequest.CourseTypeDescription
            };

            return await this.iCouRepo.PostCourseTypes(Id, couReq);
        }
    }
}
