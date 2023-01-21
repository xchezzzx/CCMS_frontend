using Blazorise;
using BlazorWeb.ConnectionService;
using BlazorWeb.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Exceptions;
using System.Security.Claims;

namespace BlazorWeb.Services
{
	public class CurrentUserService : ICurrentUserService
    {
		private UserDT CurrentUser { get; set; }
		private AuthenticationStateProvider _authProv;
		private readonly IConnectionService _connectionService;
		private readonly IUserService _userService;

        public CurrentUserService(AuthenticationStateProvider AuthProv, IConnectionService connectionService, IUserService userService)
		{
			this._authProv = AuthProv;
			_connectionService = connectionService;
			_userService = userService;
		}

		public async Task<UserDT> GetCurrentUserAsync()
		{ 
			if (CurrentUser == null)
			{
                var claims = (await _authProv.GetAuthenticationStateAsync()).User.Claims;
				var auth0Id = "asdasdasd";/*claims.Where(c => c.Type == "id").First().Value;*/
				try
				{
					CurrentUser = await _userService.GetCurrentUserAsync(auth0Id);
				}
				catch
				{
					Console.WriteLine("asdasdads");
					CurrentUser = new UserDT();

					CurrentUser.FirstName = claims.Where(c => c.Type == "given_name").First().Value != null ? claims.Where(c => c.Type == "given_name").First().Value : "Unknown";

					CurrentUser.LastName = claims.Where(c => c.Type == "family_name").First().Value != null ? claims.Where(c => c.Type == "family_name").First().Value : "Unknown";

					CurrentUser.Email = claims.Where(c => c.Type == "email").First().Value;

					if (claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").First().Value == "[\"Administrator\"]")
					{
						CurrentUser.RoleId = Roles.Administrator;
					}
					else if (claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").First().Value == "[\"Operator\"]")
					{
						CurrentUser.RoleId = Roles.Operator;
					}
					else CurrentUser.RoleId = Roles.Participant;


					CurrentUser.Password = auth0Id;
					
					CurrentUser = await _userService.AddNewUserAsync(CurrentUser);
				}
			}

			return CurrentUser;
		}

		public async Task SetCurrentUser(UserDT user){
			CurrentUser ??= user;
		}



	}
}
