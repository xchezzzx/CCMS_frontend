using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Models.DataTransferModels
{
	public partial class ExerciseLangDT
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
