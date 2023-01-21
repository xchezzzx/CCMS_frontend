using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.Services.ConnectionService
{
    public interface IConnectionService
    {
        Task<HubConnection> GetTeamHubConnectionAsync();
        Task<HubConnection> GetExercisesHubConnectionAsync();
        Task<HubConnection> GetCompetitionHubConnectionAsync();

        Task<HubConnection> GetUserHubConnectionAsync();
    }
}
