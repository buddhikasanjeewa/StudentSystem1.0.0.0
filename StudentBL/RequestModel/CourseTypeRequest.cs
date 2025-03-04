 namespace StudentBL.RequestModel
{
    public class CourseTypeRequest
    {
        public Guid Uid { get; set; }

        public string CourseTypeId { get; set; } = null!;

        public string CourseTypeDescription { get; set; } = null!;

        public string CourseTypeName { get; set; } = null!;
    }
}
