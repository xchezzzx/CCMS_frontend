using SharedLib.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorWeb.Services.ConnectionService;

namespace BlazorWeb.Services.UserService
{
    public class UserService : IUserService
    {
        private IConnectionService _connectionService;
        public UserService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        private UserDT getUser { get; set; }
        private List<UserDT> _getAllUsers { get; set; }


        public async Task DeleteUserAsync(int id)
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

        public async Task<UserDT> GetCurrentUserAsync(string auth0Id)
        {
            UserDT currentUser = new UserDT();
            try
            {
                var connection = await _connectionService.GetUserHubConnectionAsync();

                connection.On<UserDT>("GetCurrentUser", c => currentUser = c);

                await connection.InvokeAsync("GetCurrentUser", auth0Id);
                Console.WriteLine(connection.State + " asddad");


            }
            catch
            {
                throw;
            }
            return currentUser;
        }

        public async Task<UserDT> AddNewUserAsync(UserDT userDT)
        {

            var _userHubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/users")
                            .Build();

            Console.WriteLine("a");
            _userHubConnection.On<UserDT>("AddNewUser", c => userDT = c);
            Console.WriteLine("b");

            Console.WriteLine(_userHubConnection.State + " asddad");

            await _userHubConnection.StartAsync();
            await _userHubConnection.InvokeAsync("AddNewUser", userDT);
            Console.WriteLine("c");
            return userDT;
        }

        public async Task<UserDT> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
