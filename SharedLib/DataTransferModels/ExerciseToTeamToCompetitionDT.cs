using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.DataTransferModels
{
	internal class ExerciseToTeamToCompetitionDT
	{
		public int? Id { get; set; }
		public int CompetitionId { get; set; }
		public int TeamId { get; set; }
		public int ExerciseId { get; set; }
		public DateTime TakeTime { get; set; }
		public DateTime? SubmitTime { get; set; }
		public TimeSpan Timeframe { get; set; }
		public TimeSpan? SubmitDuration { get; set; }
		public int ExerciseStateId { get; set; }
		public string? SolutionLink { get; set; }
		public string? Comment { get; set; }
		public string? FileLink { get; set; }
		public int? ApprovedPoints { get; set; }
		public DateTime CreateDate { get; set; }
		public int CreateUserId { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateUserId { get; set; }
		public int StatusId { get; set; }
	}
}
