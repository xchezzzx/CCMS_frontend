using BlazorWeb.Interfaces;
using BlazorWeb.Models.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.Services
{
	public class ExerciseService : IExerciseInterface
	{

		public ExerciseService()
		{

		}

		private ExerciseDT getExercise { get; set; }
		private List<ExerciseDT> getAllExercises { get; set; }

		public async Task AddExercise(ExerciseDT ExerciseDT)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteExercise(ExerciseDT ExerciseDT)
		{
			throw new NotImplementedException();
		}

		public async Task<List<ExerciseDT>> GetAllExercisesAsync()
		{
			if (getAllExercises == null)
			{
				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/teams")
					.Build();

				HubConnection.On<List<ExerciseDT>>("Send", c => getAllExercises = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("SendTeams");
				await HubConnection.StopAsync();
			}
			return getAllExercises;
		}

		public async Task<ExerciseDT> GetExerciseByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateExercise(ExerciseDT ExerciseDT)
		{
			throw new NotImplementedException();
		}
	}
}
