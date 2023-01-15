using BlazorWeb.Interfaces;
using SharedLib.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.Services
{
	public class TeamService : ITeamService
	{
		public TeamService() { }

		private List<TeamDT> _getAllTeams { get; set; }
		private TeamDT getTeam { get; set; }


		public async Task<string> AddTeamAsync(TeamDT teamDT)
		{
			string messageFromServer = string.Empty;

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/teams")
							.WithAutomaticReconnect()
							.Build();

			HubConnection.On<string>("Add", msg =>
			{
				messageFromServer = msg;
			});

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("AddNewTeam", teamDT);
			await HubConnection.DisposeAsync();

			return messageFromServer;
		}

		public async Task DeleteTeamAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<TeamDT>> GetAllTeamsAsync()
		{
			HubConnection HubConnection = new HubConnectionBuilder()
				.WithUrl("https://localhost:7206/teams")
				.Build();

			HubConnection.On<List<TeamDT>>("GetAllTeams", c => _getAllTeams = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllTeams");
			await HubConnection.StopAsync();

			return _getAllTeams;
		}

		public async Task<TeamDT> GetTeamByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateTeamAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
