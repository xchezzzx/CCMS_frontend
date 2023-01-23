using Microsoft.AspNetCore.SignalR.Client;
using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.CatalogueService
{
    public class CatalogueService : ICatalogueService
    {

        public CatalogueService() { }
        private List<ExerciseCategoryDT> _getAllCategories { get; set; }
        private List<ExerciseLangDT> _getAllLangs { get; set; }
        private List<ExercisePlatformDT> _getAllPlatforms { get; set; }

        private ExerciseCategoryDT getCategory { get; set; }
        private ExerciseLangDT getLang { get; set; }
        private ExercisePlatformDT getPlatform { get; set; }


        public async Task<ExerciseCategoryDT> AddNewExerciseCategoryAsync(ExerciseCategoryDT ExerciseCategoryDT)
        {
            try
            {
				string messageFromServer = string.Empty;

				HubConnection HubConnection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/exercises")
								.WithAutomaticReconnect()
								.Build();

				HubConnection.On<ExerciseCategoryDT>("AddNewExerciseCategory", msg =>
				{
					ExerciseCategoryDT = msg;
				});

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("AddNewExerciseCategory", ExerciseCategoryDT);

				return ExerciseCategoryDT;
			}
            catch 
            {

                throw;
            }
        }

        public async Task<ExerciseLangDT> AddNewExerciseLanguageAsync(ExerciseLangDT ExerciseLangDT)
        {
            try
            {

				HubConnection HubConnection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/exercises")
								.WithAutomaticReconnect()
								.Build();

				HubConnection.On<ExerciseLangDT>("AddNewExerciseLang", msg =>
				{
					ExerciseLangDT = msg;
				});

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("AddNewExerciseLang", ExerciseLangDT);
				await HubConnection.DisposeAsync();

				return ExerciseLangDT;
			}
            catch 
            {

                throw;
            }
        }

        public async Task<ExercisePlatformDT> AddNewExercisePlatformAsync(ExercisePlatformDT ExercisePlatformDT)
        {
            try
            {

				string messageFromServer = string.Empty;

				HubConnection HubConnection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/exercises")
								.WithAutomaticReconnect()
								.Build();

				HubConnection.On<ExercisePlatformDT>("AddNewExercisePlatform", msg =>
				{
					ExercisePlatformDT = msg;
				});

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("AddNewExercisePlatform", ExercisePlatformDT);
				await HubConnection.DisposeAsync();

				return ExercisePlatformDT;
			}
            catch 
            {

                throw;
            }
        }

        public async Task DeleteExerciseCategoryAsync(ExerciseCategoryDT ExerciseCategoryDT)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteExerciseLanguageAsync(ExerciseLangDT ExerciseLangDT)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteExercisePlatformAsync(ExercisePlatformDT ExercisePlatformDT)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExerciseCategoryDT>> GetAllExerciseCategoriesAsync()
        {
            try
            {

				HubConnection HubConnection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/exercises")
								.Build();

				HubConnection.On<List<ExerciseCategoryDT>>("GetAllExerciseCategories", c => _getAllCategories = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("GetAllExerciseCategories");
				await HubConnection.StopAsync();

				return _getAllCategories;
			}
            catch 
            {

                throw;
            }
        }

        public async Task<List<ExerciseLangDT>> GetAllExerciseLanguagesAsync()
        {
            try
            {
				HubConnection HubConnection = new HubConnectionBuilder()
										.WithUrl("https://localhost:7206/exercises")
										.Build();

				HubConnection.On<List<ExerciseLangDT>>("GetAllExerciseLangs", c => _getAllLangs = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("GetAllExerciseLangs");
				await HubConnection.StopAsync();

				return _getAllLangs;
			}
            catch 
            {

                throw;
            }
        }

        public async Task<List<ExercisePlatformDT>> GetAllExercisePlatformsAsync()
        {
            try
            {
				HubConnection HubConnection = new HubConnectionBuilder()
														.WithUrl("https://localhost:7206/exercises")
														.Build();

				HubConnection.On<List<ExercisePlatformDT>>("GetAllExercisePlatforms", c => _getAllPlatforms = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("GetAllExercisePlatforms");
				await HubConnection.StopAsync();

				return _getAllPlatforms;
			}
            catch 
            {

                throw;
            }
        }

        public async Task<ExerciseCategoryDT> GetExerciseCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ExerciseLangDT> GetExerciseLanguageByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ExercisePlatformDT> GetExercisePlatformByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateExerciseCategoryAsync(ExerciseCategoryDT ExerciseCategoryDT)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateExerciseLanguageAsync(ExerciseLangDT ExerciseLangDT)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateExercisePlatformAsync(ExercisePlatformDT ExercisePlatformDT)
        {
            throw new NotImplementedException();
        }
    }
}
