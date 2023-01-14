using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Models.DataTransferModels
{
    public class CompetitionDT
    {
        public int? Id { get; set; }
        [Required]
		public string Name { get; set; } = null!;
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int NumberConcTasks { get; set; }
        [Required]
		public string Hashtag { get; set; } = null!;
        public string State { get; set; }
		public DateTime CreateDate { get; set; }
		public int CreateUserId { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateUserId { get; set; }
		public int StatusId { get; set; }
    }
}
