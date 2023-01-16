using BlazorWeb.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using SharedLib.DataTransferModels;

namespace BlazorWeb.Services
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


		public async Task<string> AddNewExerciseCategoryAsync(ExerciseCategoryDT ExerciseCategoryDT)
		{
			string messageFromServer = string.Empty;

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/exercises")
							.WithAutomaticReconnect()
							.Build();

			Console.WriteLine("1. HubConnction");

			HubConnection.On<string>("Add", msg =>
			{
				messageFromServer = msg;
			});

			await HubConnection.StartAsync();
			Console.WriteLine("2 Start");

			await HubConnection.InvokeAsync("AddNewExerciseCategory", ExerciseCategoryDT);

			Console.WriteLine("3 Invoke");

			return messageFromServer;
		}

		public async Task<string> AddNewExerciseLanguageAsync(ExerciseLangDT ExerciseLangDT)
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
			await HubConnection.InvokeAsync("AddNewExerciseLang", ExerciseLangDT);
			await HubConnection.DisposeAsync();

			return messageFromServer;
		}

		public async Task<string> AddNewExercisePlatformAsync(ExercisePlatformDT ExercisePlatformDT)
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
			await HubConnection.InvokeAsync("AddNewExercisePlatform", ExercisePlatformDT);
			await HubConnection.DisposeAsync();

			return messageFromServer;
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
			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/exercises")
							.Build();

			HubConnection.On<List<ExerciseCategoryDT>>("Get", c => _getAllCategories = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllExerciseCategories");
			await HubConnection.StopAsync();

			return _getAllCategories;
		}

		public async Task<List<ExerciseLangDT>> GetAllExerciseLanguagesAsync()
		{
			HubConnection HubConnection = new HubConnectionBuilder()
										.WithUrl("https://localhost:7206/exercises")
										.Build();

			HubConnection.On<List<ExerciseLangDT>>("Get", c => _getAllLangs = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllExerciseLangs");
			await HubConnection.StopAsync();

			return _getAllLangs;
		}

		public async Task<List<ExercisePlatformDT>> GetAllExercisePlatformsAsync()
		{
			HubConnection HubConnection = new HubConnectionBuilder()
										.WithUrl("https://localhost:7206/exercises")
										.Build();

			HubConnection.On<List<ExercisePlatformDT>>("Get", c => _getAllPlatforms = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllExercisePlatforms");
			await HubConnection.StopAsync();

			return _getAllPlatforms;
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
