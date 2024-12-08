using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.RequestModel
{
	public class StudentRequest
	{

		/*
	 *Author:Buddhika Walpita 
	 * Date:2024-11-12
	 * Description:Request Model for Student
	 */
		[Key]
		public Guid Id { get; set; }

		public required string StudentCode { get; set; }

		public required string FirstName { get; set; }

		public required string LastName { get; set; }

		public required string Mobile { get; set; }
		public required string Email { get; set; }
		public required string NIC { get; set; }

		public string? Address { get; set; }


		public  DateTime? Dob { get; set; }
	}
}
