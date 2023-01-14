using BlazorWeb.Interfaces;
using BlazorWeb.Models.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.Services
{
	public class TeamService : ITeamService
	{
		public TeamService() { }

		private List<TeamDT> _getAllTeams { get; set; }
		private TeamDT getTeam { get; set; }


		public async Task AddTeam(TeamDT TeamDT)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteTeam(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<TeamDT>> GetAllTeamsAsync()
		{
			if (_getAllTeams == null)
			{
				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/teams")
					.Build();

				HubConnection.On<List<TeamDT>>("Send", c => _getAllTeams = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("SendTeams");
				await HubConnection.StopAsync();
			}
			return _getAllTeams;
		}

		public async Task<TeamDT> GetTeamByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateTeam(int id)
		{
			throw new NotImplementedException();
		}
	}
}
