using SharedLib.Enums;
using System.ComponentModel.DataAnnotations;

namespace SharedLib.DataTransferModels
{
    public partial class ExerciseCategoryDT
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

		public DateTime CreateDate { get; set; }
		public int CreateUserId { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateUserId { get; set; }
		public string Status { get; set; }
		public EntityStatuses StatusId { get; set; }
	}
}
