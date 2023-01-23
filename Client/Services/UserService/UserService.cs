using SharedLib.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;
using BlazorWeb.Services.ConnectionService;
using SharedLib.Constants.Enums;
using BlazorWeb.Services.CurrentUserService;

namespace BlazorWeb.Services.UserService
{
	public class UserService : IUserService
	{
		private readonly IConnectionService _connectionService;
		private readonly ICurrentUserService _currentUserService;
		public UserService(IConnectionService connectionService, ICurrentUserService currentUserService)
		{
			_connectionService = connectionService;
			_currentUserService = currentUserService;
		}

		public async Task<UserDT> GetCurrentUserAsync(UserDT userDT)
		{
			UserDT currentUser = new UserDT();
			try
			{
				var connection = await _connectionService.GetUserHubConnectionAsync();

				connection.On<UserDT>("GetCurrentUser", c => currentUser = c);

				await connection.InvokeAsync("GetCurrentUser", userDT);
			}
			catch
			{
				throw;
			}
			return currentUser;
		}

		public async Task<UserDT> AddNewUserAsync(UserDT userDT)
		{
			UserDT addUser = new();

			try
			{
				var connection = await _connectionService.GetUserHubConnectionAsync();

				connection.On<UserDT>("AddNewUser", c => userDT = c);

				await connection.StartAsync();
				await connection.InvokeAsync("AddNewUser", userDT);
			}
			catch
			{
				throw;
			}

			return addUser;
		}

		public async Task<List<UserDT>> GetAllUsersAsync()
		{
			List<UserDT> _getAllUsers = new();

			try
			{
				//var connection = await _connectionService.GetUserHubConnectionAsync();

				HubConnection connection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/users")
								.Build();

				connection.On<List<UserDT>>("GetAllUsers", c => _getAllUsers = c);

				await connection.StartAsync();
				await connection.InvokeAsync("GetAllUsers");
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return _getAllUsers;
		}

		public async Task<List<UserDT>> GetAllActiveUsersAsync()
		{
			List<UserDT> _getAllUsers = new();

			try
			{
				//var connection = await _connectionService.GetUserHubConnectionAsync();

				HubConnection connection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/users")
								.Build();

				connection.On<List<UserDT>>("GetAllActiveUsers", c => _getAllUsers = c);

				await connection.StartAsync();
				await connection.InvokeAsync("GetAllActiveUsers");
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return _getAllUsers;
		}

		public async Task<string> UpdateUserAsync(UserDT userDT)
		{
			string messageFromServer = string.Empty;

			try
			{
				var connection = await _connectionService.GetUserHubConnectionAsync();
				var currentUserId = (await _currentUserService.GetCurrentUserAsync()).Id;

				connection.On<string>("UpdateUser", msg => messageFromServer = msg);

				await connection.StartAsync();
				await connection.InvokeAsync("UpdateUser", userDT, currentUserId);
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return messageFromServer;
		}

		public async Task<string> DeleteUserByIdAsync(int userId)
		{
			string messageFromServer = string.Empty;

			try
			{
				//var connection = await _connectionService.GetUserHubConnectionAsync();

				HubConnection connection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/users")
								.Build();

				var currentUserId = (await _currentUserService.GetCurrentUserAsync()).Id;

				connection.On<string>("DeleteUserById", msg => messageFromServer = msg);

				await connection.StartAsync();
				await connection.InvokeAsync("DeleteUserById", userId, currentUserId);
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return messageFromServer;
		}

		public async Task<UserDT> GetUserByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<string> AssignRoleToUser(int userId, Roles role)
		{
			string messageFromServer = string.Empty;

			try
			{
				var connection = await _connectionService.GetUserHubConnectionAsync();
				var currentUserId = (await _currentUserService.GetCurrentUserAsync()).Id;

				connection.On<string>("AssignRoleToUser", msg => messageFromServer = msg);

				await connection.StartAsync();
				await connection.InvokeAsync("AssignRoleToUser", userId, role, currentUserId);
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return messageFromServer;
		}

		public async Task<CompetitionDT> GetOperatorCurrentOrNearestCompetition(int operatorId)
		{
			CompetitionDT _getOperatorCurrentOrNearestCompetition = new();

			try
			{
				HubConnection connection = new HubConnectionBuilder()
									.WithUrl("https://localhost:7206/users")
									.Build();

				var currentUserId = (await _currentUserService.GetCurrentUserAsync()).Id;

				connection.On<CompetitionDT>("DeleGetOperatorCurrentOrNearestCompetitionteUserById", c => _getOperatorCurrentOrNearestCompetition = c);

				await connection.StartAsync();
				await connection.InvokeAsync("GetOperatorCurrentOrNearestCompetition", operatorId);
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return _getOperatorCurrentOrNearestCompetition;
		}

		public async Task<CompetitionDT> GetParticipantCurrentOrNearestCompetition(int participantId)
		{
			CompetitionDT _getParticipantCurrentOrNearestCompetition = new();
			
			try
			{
				HubConnection connection = new HubConnectionBuilder()
									.WithUrl("https://localhost:7206/users")
									.Build();

				var currentUserId = (await _currentUserService.GetCurrentUserAsync()).Id;

				connection.On<CompetitionDT>("GetParticipantCurrentOrNearestCompetition", c => _getParticipantCurrentOrNearestCompetition = c);

				await connection.StartAsync();
				await connection.InvokeAsync("GetParticipantCurrentOrNearestCompetition", participantId);
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return _getParticipantCurrentOrNearestCompetition;
		}

		public async Task<List<CompetitionDT>> GetFiveCurrentOrNearestCompetitions()
		{
			List<CompetitionDT> _getFiveCurrentOrNearestCompetitions = new();

			try
			{
				HubConnection connection = new HubConnectionBuilder()
									.WithUrl("https://localhost:7206/users")
									.Build();

				var currentUserId = (await _currentUserService.GetCurrentUserAsync()).Id;

				connection.On<List<CompetitionDT>>("GetFiveCurrentOrNearestCompetitions", c => _getFiveCurrentOrNearestCompetitions = c);

				await connection.StartAsync();
				await connection.InvokeAsync("GetFiveCurrentOrNearestCompetitions");
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return _getFiveCurrentOrNearestCompetitions;
		}

		public async Task<TeamDT> GetParticipantTeam(int participantId)
		{
			TeamDT _getParticipantTeam = new();

			try
			{
				HubConnection connection = new HubConnectionBuilder()
									.WithUrl("https://localhost:7206/users")
									.Build();

				var currentUserId = (await _currentUserService.GetCurrentUserAsync()).Id;

				connection.On<TeamDT>("GetParticipantTeam", c => _getParticipantTeam = c);

				await connection.StartAsync();
				await connection.InvokeAsync("GetParticipantTeam", participantId);
				await connection.StopAsync();
			}
			catch
			{
				throw;
			}

			return _getParticipantTeam;
		}
	}
}
