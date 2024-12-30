namespace StudentSystemWebApi.StudentBL.RequestModel
{
    public class CourseRequest
    {
        public Guid UID { get; set; }
        public required string CourseCode { get; set; }
        public Guid CoureTypeUid { get; set; }
        public required string  Course_Description { get; set; }
    }
}
