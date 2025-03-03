using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentSystemWebApi.DataAccessLayer.Models;
using StudentSystemWebApi.DataAccessLayer.Repository.Interfaces;
using StudentSystemWebApi.DataAccessLayer.RequestModel;

namespace StudentSystemWebApi.DataAccessLayer.Repository.Classes
{
    public class CourseTypeRepo : ICourseTypeRepo
    {
        private readonly GitstudentContext dbContext;
        private int retunVal;
        public CourseTypeRepo(GitstudentContext dbContext)
        {
            this.dbContext = dbContext;
        }

       public async Task<int> DeleteCourseTypes(Guid Id)
        {
            try
            {

                var cou = await dbContext.CourseTypes.FindAsync(Id);

                dbContext.CourseTypes.Remove(cou);  //Remove the course type
                await dbContext.SaveChangesAsync(); //Update the database
                retunVal = 1;

                return retunVal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CourseType>> GetCoursesTypes()
        {
            if (dbContext.CourseTypes == null)  //Check Course Type Null
            {
                throw new Exception("Not Found");
            }

            var paramSearchCri = new SqlParameter("@SeachCriteria", "");
            var paramType = new SqlParameter("@type", 1);
            var coursetypes = await this.dbContext.CourseTypes
                      .FromSqlRaw("Get_CourseTypeData @SeachCriteria,@type", paramSearchCri, paramType)
                      .ToListAsync();
            return coursetypes; 
        }

      public  async Task<List<CourseType>> GetCoursesTypes(string searchCriteria)
        {
            if (dbContext.CourseTypes == null)  //Check Student Null
            {
                throw new Exception("Not Found");
            }

            var paramSearchCri = new SqlParameter("@SeachCriteria", searchCriteria);
            var paramType = new SqlParameter("@type", 2);
            var coursetypes = await this.dbContext.CourseTypes
                      .FromSqlRaw("Get_CourseTypeData @SeachCriteria,@type", paramSearchCri, paramType)
                      .ToListAsync();
            return coursetypes;
        }

        public async Task<List<CourseType>> GetCoursesTypes(Guid Id)
        {
            try
            {

                var result = dbContext.CourseTypes.Where(x => x.Uid == Id);
                if (result.Any())
                {
                    return await result.ToListAsync();
                }
                else
                {
                    throw new Exception("No data found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       public  async Task<int> PostCourseTypes(CourseTypeRequest CouRequest)
        {
            using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))  //Begin transaction
            {
                try
                {
                    var paramList = new List<SqlParameter>()
                    {
                       new SqlParameter("@UID", Guid.NewGuid()),
                       new SqlParameter("@Course_Type_ID", CouRequest.CourseTypeId),
                       new SqlParameter("@Course_Type_Description", CouRequest.CourseTypeDescription),
                    };

                    var result = await Task.Run(() => dbContext.Database
                                           .ExecuteSqlRawAsync(@"exec Save_Course_Type @UID,@Course_Type_ID,@Course_Type_Description", paramList.ToArray()));

                    //	dbContext.StudentPersonals.Add(domainModeStudent);
                    //await dbContext.SaveChangesAsync();
                    transaction.Commit();   //Commit  transaction
                    retunVal = 1;
                    return retunVal;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();  //Rollback transaction if any exeception 

                    throw new Exception(ex.Message);
                }
            }
        }

     public    async Task<int> PostCourseTypes(Guid Id, CourseTypeRequest CouRequest)
        {
            using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))  //Begin transaction
            {
                try
                {

                    var cou = await dbContext.CourseTypes.FindAsync(Id);
                    if (cou != null)
                    {
                        cou.Uid = CouRequest.Uid;
                        cou.CourseTypeId = CouRequest.CourseTypeId;
                        cou.CourseTypeDescription = CouRequest.CourseTypeDescription;
                    

                    }
                    await dbContext.SaveChangesAsync();
                    transaction.Commit();
                    retunVal = 1;
                    return retunVal;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();  //Rollback transaction if any exeception 

                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
