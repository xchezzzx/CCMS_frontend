using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Models.DataTransferModels
{
    public partial class ExerciseCategoryDT
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
