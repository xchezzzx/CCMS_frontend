using Microsoft.AspNetCore.SignalR.Client;
using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        public ExerciseService()
        {

        }

        private ExerciseDT _getExercise { get; set; }

        public async Task<ExerciseDT> AddNewExercise(ExerciseDT exerciseDT)
        {
            try
            {

				HubConnection HubConnection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/exercises")
								.WithAutomaticReconnect()
								.Build();

				HubConnection.On<ExerciseDT>("AddNewExercise", msg =>
				{
					exerciseDT = msg;
				});

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("AddNewExercise", exerciseDT);
				await HubConnection.DisposeAsync();

				return exerciseDT;
			}
            catch 
            {

                throw;
            }
        }

        public async Task DeleteExercise(ExerciseDT exerciseDT)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExerciseDT>> GetAllExercisesAsync()
        {
            try
            {
				List<ExerciseDT> _getAllExercises = new();

				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/exercises")
					.Build();

				HubConnection.On<List<ExerciseDT>>("GetAllExercises", c => _getAllExercises = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("GetAllExercises");
				await HubConnection.StopAsync();

				return _getAllExercises;
			}
            catch 
            {

                throw;
            }
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
