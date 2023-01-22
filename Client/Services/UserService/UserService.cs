using SharedLib.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorWeb.Services.ConnectionService;
using SharedLib.Constants.Enums;

namespace BlazorWeb.Services.UserService
{
	public class UserService : IUserService
	{
		private IConnectionService _connectionService;
		public UserService(IConnectionService connectionService)
		{
			_connectionService = connectionService;
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
				var connection = await _connectionService.GetUserHubConnectionAsync();

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
				var connection = await _connectionService.GetUserHubConnectionAsync();

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

		public async Task UpdateUserAsync(UserDT userDT, int userUpdateId)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteUserByIdAsync(int userId, int userUpdateId)
		{
			throw new NotImplementedException();
		}

		public async Task<UserDT> GetUserByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task AssignRoleToUser(int userId, Roles role, int userUpdateId)
		{
			throw new NotImplementedException();
		}
	}
}
