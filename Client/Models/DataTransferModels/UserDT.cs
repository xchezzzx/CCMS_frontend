using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Models.DataTransferModels
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
		public int RoleId { get; set; }
		[Required, Display(Name = "summary points")]
		public int? PointsSummary { get; set; }
	}
}