using SharedLib.Constants.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SharedLib.DataTransferModels
{
	public class ExerciseDT
	{
		public int? Id { get; set; }
		[Required, Display(Name = "label")]
		public string Name { get; set; } = null!;

		[Required, Display(Name = "description")]
		[MaxLength(2000, ErrorMessage = "The maximum length is 2000 charachters.")]
		public string Content { get; set; } = null!;

		[Required, Display(Name = "category")]
		public int CategoryId { get; set; }

		[Required, Display(Name = "language")]
		public int LangId { get; set; }

		[Required, Display(Name = "platform")]
		public int PlatformId { get; set; }

		[Required, Display(Name = "time")]
		public TimeSpan Timeframe { get; set; }

		[Required, Display(Name = "points")]
		public int Points { get; set; }
		public int Fine { get; set; }
		public bool IfHasBonus { get; set; }
		public string? BonusContent { get; set; }
		public TimeSpan? BonusTimeframe { get; set; }
		public int? BonusPoints { get; set; }
		public DateTime CreateDate { get; set; }
		public int CreateUserId { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateUserId { get; set; }

		public string Status { get; set; }
		public EntityStatuses StatusId { get; set; }
	}
}
