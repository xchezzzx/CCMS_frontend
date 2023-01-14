using System.ComponentModel.DataAnnotations;

namespace SharedLib.DataTransferModels
{
	public partial class ExerciseLangDT
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
