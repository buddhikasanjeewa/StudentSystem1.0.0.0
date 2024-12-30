using StudentSystemWebApi.StudentBL.Interfaces;

namespace StudentSystemWebApi.StudentBL.Classes
{
    public class Course:ICourse
    {
        public Guid UID { get; set; }
        public string CourseCode { get; set; }
        public Guid CoureTypeUid { get; set; }
        public string Course_Description { get; set; }
    }
}
