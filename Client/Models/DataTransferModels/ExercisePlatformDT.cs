using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Models.DataTransferModels
{
	public partial class ExercisePlatformDT
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
