using SharedLib.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.Services.TeamService
{
	public class TeamService : ITeamService
	{
		public TeamService() { }

		public async Task<TeamDT> AddTeamAsync(TeamDT teamDT)
		{
			
			try
			{
				HubConnection HubConnection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/teams")
								.WithAutomaticReconnect()
								.Build();

				HubConnection.On<TeamDT>("AddNewTeam", newTeamDT =>
				{
					teamDT = newTeamDT;
				});

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("AddNewTeam", teamDT);
				await HubConnection.DisposeAsync();
			}
			catch 
			{

				throw;
			}

			return teamDT;
		}

		public async Task DeleteTeamAsync(int id)
		{

			try
			{
				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/teams")
					.Build();


				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("DeleteTeam", id);
				await HubConnection.StopAsync();
			}
			catch
			{
				throw;
			}

		}

		public async Task<List<TeamDT>> GetAllTeamsAsync()
		{
			List<TeamDT> _getAllTeams = new();
			try
			{
				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/teams")
					.Build();

				HubConnection.On<List<TeamDT>>("GetAllTeams", c => _getAllTeams = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("GetAllTeams");
				await HubConnection.StopAsync();
			}
			catch 
			{
				throw;
			}

			return _getAllTeams;
		}

		public async Task<TeamDT> GetTeamByIdAsync(int id)
		{
			TeamDT teamDT = new();
			try
			{
				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/teams")
					.Build();

				HubConnection.On<TeamDT>("GetTeamById", c => teamDT = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("GetTeamById");
				await HubConnection.StopAsync();
			}
			catch
			{
				throw;
			}

			return teamDT;
		}

		public async Task UpdateTeamAsync(int id)
		{

			try
			{
				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/teams")
					.Build();


				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("UpdateTeam", id);
				await HubConnection.StopAsync();
			}
			catch
			{
				throw;
			}
		}
	}
}
