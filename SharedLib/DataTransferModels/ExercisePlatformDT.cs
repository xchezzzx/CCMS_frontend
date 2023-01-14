using System.ComponentModel.DataAnnotations;

namespace SharedLib.DataTransferModels
{
	public partial class ExercisePlatformDT
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
