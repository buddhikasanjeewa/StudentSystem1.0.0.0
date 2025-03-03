namespace StudentSystemWebApi.StudentBL.Interfaces
{
    public interface ICourseType
    {
        public Guid Uid { get; set; }

        public string CourseTypeId { get; set; }

        public string CourseTypeDescription { get; set; } 

     
    }
}
