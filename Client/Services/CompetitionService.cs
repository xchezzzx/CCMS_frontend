using BlazorWeb.Interfaces;
using SharedLib.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.Services
{
	public class CompetitionService : ICompetitionService
	{
		public CompetitionService()
		{

		}

		private List<CompetitionDT> _getAllCompetitions { get; set; }
		private CompetitionDT getCompetition { get; set; }

		public async Task<List<CompetitionDT>> GetAllCompetitionsAsync()
		{
			HubConnection HubConnection = new HubConnectionBuilder()
				.WithUrl("https://localhost:7206/competitions")
				.Build();

			HubConnection.On<List<CompetitionDT>>("Get", c => _getAllCompetitions = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllCompetitions");
			await HubConnection.StopAsync();

			return _getAllCompetitions;
		}

		public async Task<CompetitionDT> GetCompetitionByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<string> AddCompetitionAsync(CompetitionDT competitionDT)
		{
			string messageFromServer = string.Empty;

			HubConnection connection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.WithAutomaticReconnect()
							.Build();

			connection.On<string>("Add", msg =>
			{
				messageFromServer = msg;
			});

			await connection.StartAsync();
			await connection.InvokeAsync("AddNewCompetition", competitionDT);
			await connection.DisposeAsync();

			return messageFromServer;
		}

		public async Task UpdateCompetitionAsync(CompetitionDT competitionDT)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteCompetitionAsync(int id)
		{
			throw new NotImplementedException();
		}
	}

}
