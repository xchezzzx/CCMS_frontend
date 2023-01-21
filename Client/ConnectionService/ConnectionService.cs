using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using System.Security.Claims;

namespace BlazorWeb.ConnectionService
{
	public class ConnectionService : IConnectionService
	{
		private readonly IAccessTokenProvider _accessTokenProvider;

		public ConnectionService(IAccessTokenProvider accessTokenProvider)
		{
			_accessTokenProvider = accessTokenProvider;
		}
		
		public async Task<HubConnection> GetTeamHubConnectionAsync()
		{
			var accessTokenResult = await _accessTokenProvider.RequestAccessToken();
			var _AccessToken = string.Empty;

			if (accessTokenResult.TryGetToken(out var token))
			{
				_AccessToken = token.Value;
			}

			_teamHubConnection ??= new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions", o => {
								o.AccessTokenProvider = () => Task.FromResult(_AccessToken);
							})
							.WithAutomaticReconnect()
							.Build();

			return _teamHubConnection;
		}


		public async Task<HubConnection> GetExercisesHubConnectionAsync()
		{
			var accessTokenResult = await _accessTokenProvider.RequestAccessToken();
			var _AccessToken = string.Empty;

			if (accessTokenResult.TryGetToken(out var token))
			{
				_AccessToken = token.Value;
			}

			_exerciseHubConnection ??= new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions", o => {
								o.AccessTokenProvider = () => Task.FromResult(_AccessToken);
							})
							.WithAutomaticReconnect()
							.Build();


			return _exerciseHubConnection;
		}

		public async Task<HubConnection> GetCompetitionHubConnectionAsync()
		{
			var accessTokenResult = await _accessTokenProvider.RequestAccessToken();
			var _AccessToken = string.Empty;

			if (accessTokenResult.TryGetToken(out var token))
			{
				_AccessToken = token.Value;
			}

			_competitionHubConnection ??= new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions", o => {
								o.AccessTokenProvider = () => Task.FromResult(_AccessToken);
							})
							.WithAutomaticReconnect()
							.Build();


			return _competitionHubConnection;
		}

		private HubConnection _competitionHubConnection;
		private HubConnection _teamHubConnection;
		private HubConnection _exerciseHubConnection;
	}
}
