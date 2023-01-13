using BlazorWeb.Models.DataTransferModels;

namespace BlazorWeb.Interfaces
{
	public interface IExerciseInterface
	{
		Task<List<ExerciseDT>> GetAllExercisesAsync();
		Task<ExerciseDT> GetExerciseByIdAsync(int id);
		Task AddExercise(ExerciseDT ExerciseDT);
		Task UpdateExercise(ExerciseDT ExerciseDT);
		Task DeleteExercise(ExerciseDT ExerciseDT);
	}
}
