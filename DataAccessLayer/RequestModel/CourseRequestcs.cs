using System.ComponentModel.DataAnnotations;

namespace StudentSystemWebApi.DataAccessLayer.RequestModel
{
    public class CourseRequest
    {
        [Key]
        public Guid Id { get; set; }

        public required string  CourseCode { get; set; }

        public Guid  CourseTypeUID { get; set; }
        public required string CourseDescription { get; set; }

        


    }
}
