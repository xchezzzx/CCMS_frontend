﻿using SharedLib.DataTransferModels;

namespace BlazorWeb.Interfaces
{
	public interface IExerciseService
	{
		Task<List<ExerciseDT>> GetAllExercisesAsync();
		Task<ExerciseDT> GetExerciseByIdAsync(int id);
		Task<string> AddExercise(ExerciseDT exerciseDT);
		Task UpdateExercise(ExerciseDT exerciseDT);
		Task DeleteExercise(ExerciseDT exerciseDT);
	}
}
