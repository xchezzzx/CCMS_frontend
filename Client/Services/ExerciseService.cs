using BlazorWeb.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using SharedLib.DataTransferModels;

namespace BlazorWeb.Services
{
	public class ExerciseService : IExerciseService
	{
		public ExerciseService()
		{

		}

		private ExerciseDT _getExercise { get; set; }
		private List<ExerciseDT> _getAllExercises { get; set; }

		public async Task<string> AddExercise(ExerciseDT exerciseDT)
		{
			string messageFromServer = string.Empty;

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/exercises")
							.WithAutomaticReconnect()
							.Build();

			HubConnection.On<string>("Add", msg =>
			{
				messageFromServer = msg;
			});

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("AddNewExercise", exerciseDT);
			await HubConnection.DisposeAsync();

			return messageFromServer;
		}

		public async Task DeleteExercise(ExerciseDT exerciseDT)
		{
			throw new NotImplementedException();
		}

		public async Task<List<ExerciseDT>> GetAllExercisesAsync()
		{
			if (_getAllExercises == null)
			{
				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/exercises")
					.Build();

				HubConnection.On<List<ExerciseDT>>("GetAllExercises", c => _getAllExercises = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("GetAllExercises");
				await HubConnection.StopAsync();
			}
			return _getAllExercises;
		}

		public async Task<ExerciseDT> GetExerciseByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateExercise(ExerciseDT exerciseDT)
		{
			throw new NotImplementedException();
		}
	}
}
