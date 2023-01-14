using SharedLib.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SharedLib.DataTransferModels
{
	public class UserDT
	{
		public int? Id { get; set; }

		[Required, Display(Name = "first name")]
		[MinLength(2, ErrorMessage = "First name is too short, 3 charachters minimum.")]
		public string FirstName { get; set; } = null!;

		[Required, Display(Name = "last name")]
		[MinLength(2, ErrorMessage = "Last name is too short, 3 charachters minimum.")]
		public string LastName { get; set; } = null!;

		[Required, Display(Name = "e-mail")]
		[EmailAddress(ErrorMessage = "Enter the valid e-mail address.")]
		public string Email { get; set; } = null!;

		[PasswordPropertyText]
		public string? Password { get; set; }

		public string Role { get; set; }
		public Roles RoleId	{ get; set; }

		[Required, Display(Name = "summary points")]
		public int? PointsSummary { get; set; }

		public DateTime CreateDate { get; set; }
		public int CreateUserId { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateUserId { get; set; }
		public string Status { get; set; }
		public EntityStatuses StatusId { get; set; }
	}
}