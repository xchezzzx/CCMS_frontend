using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.ConnectionService
{
	public interface IConnectionService
	{
		Task<HubConnection> GetTeamHubConnectionAsync();
		Task<HubConnection> GetExercisesHubConnectionAsync();
		Task<HubConnection> GetCompetitionHubConnectionAsync();
	}
}
