using BlazorWeb.Interfaces;
using BlazorWeb.Models.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.Services
{
	public class UserService : IUserService
	{

		public UserService() { }

		private UserDT getUser { get; set; }
		private List<UserDT> _getAllUsers { get; set; }

		public async Task AddUser(UserDT userDT)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteUser(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<UserDT>> GetAllUsersAsync()
		{
			if (_getAllUsers == null)
			{
				HubConnection HubConnection = new HubConnectionBuilder()
					.WithUrl("https://localhost:7206/users")
					.Build();

				HubConnection.On<List<UserDT>>("Send", c => _getAllUsers = c);

				await HubConnection.StartAsync();
				await HubConnection.InvokeAsync("SendCompetitions");
				await HubConnection.StopAsync();
			}
			return _getAllUsers;
		}

		public async Task<UserDT> GetUserByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateUser(int id)
		{
			throw new NotImplementedException();
		}
	}
}
