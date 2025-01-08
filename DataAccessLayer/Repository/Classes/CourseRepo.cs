using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentSystemWebApi.DataAccessLayer.Models;
using StudentSystemWebApi.DataAccessLayer.Repository.Interfaces;
using StudentSystemWebApi.DataAccessLayer.RequestModel;

namespace StudentSystemWebApi.DataAccessLayer.Repository.Classes
{
    public class CourseRepo : ICourseRepo
    {
     


        private readonly GitstudentContext dbContext;
        public string ConnectionString { get; set; }

        private int retunVal;
        public CourseRepo(GitstudentContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> DeleteCourses(Guid Id)
        {

            try
            {
              
                var cou = await dbContext.Courses.FindAsync(Id);

                dbContext.Courses.Remove(cou);  //Remove the student 
                await dbContext.SaveChangesAsync(); //Update the database
                retunVal = 1;

                return retunVal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Course>> GetCourses()
        {
         
            if (dbContext.StudentPersonals == null)  //Check Student Null
            {
                throw new Exception("Not Found");
            }

            var paramSearchCri = new SqlParameter("@SeachCriteria", "");
            var paramType = new SqlParameter("@type", 1);
            var courses = await this.dbContext.Courses
                      .FromSqlRaw("Get_CourseData  @SeachCriteria,@type", paramSearchCri, paramType)
                      .ToListAsync();
            return courses;
            //	return await dbContext.StudentPersonals.ToListAsync();
        }


        public async Task<List<Course>> GetCourses(string searchCriteria)
        {
          
            if (dbContext.StudentPersonals == null)  //Check Student Null
            {
                throw new Exception("Not Found");
            }

            var paramSearchCri = new SqlParameter("@SeachCriteria", searchCriteria);
            var paramType = new SqlParameter("@type", 2);
            var courses = await this.dbContext.Courses
                      .FromSqlRaw("Get_CourseData  @SeachCriteria,@type", paramSearchCri, paramType)
                      .ToListAsync();
            return courses;
        }

        public async Task<List<Course>> GetCourses(Guid Id)
        {
            try
            {
               
                var result = dbContext.Courses.Where(x => x.Uid == Id);
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
        public async Task<int> PostCourses(CourseRequest CouRequest)
        {
       
            using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))  //Begin transaction
            {
                try
                {
                    var paramList = new List<SqlParameter>()
                    {
                       new SqlParameter("@UID", Guid.NewGuid()),
                       new SqlParameter("@Course_Code", CouRequest.CourseCode),
                       new SqlParameter("@Course_Type_UID",CouRequest.CourseTypeUID),
                       new SqlParameter("@Course_Description", CouRequest.CourseDescription),
           

                    };
                  
                    var result = await Task.Run(() => dbContext.Database
                                           .ExecuteSqlRawAsync(@"exec Save_Course @UID,@Course_Code,@Course_Type_UID,@Course_Description", paramList.ToArray()));

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

        public async Task<int> PostCourses(Guid Id, CourseRequest CouRequest)
        {

         
            using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))  //Begin transaction
            {
                try
                {

                    var cou = await dbContext.Courses.FindAsync(Id);
                    if (cou != null)
                    {
                    cou.Uid=CouRequest.Id;
                    cou.CourseCode=CouRequest.CourseCode;
                    cou.CourseDescription=CouRequest.CourseDescription;
                    cou.CourseTypeUid=CouRequest.CourseTypeUID;

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
