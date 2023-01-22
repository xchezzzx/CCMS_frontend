using Blazorise;
using BlazorWeb.Services.ConnectionService;
using BlazorWeb.Services.UserService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;
using SharedLib.Exceptions;
using SharedLib.Services.ExceptionBuilderService;
using System.Security.Claims;

namespace BlazorWeb.Services.CurrentUserService
{
	public class CurrentUserService : ICurrentUserService
	{
		private UserDT CurrentUser { get; set; }
		private AuthenticationStateProvider _authProv;
		private readonly IConnectionService _connectionService;
		//private readonly IUserService _userService;
		private readonly IExceptionBuilderService _exceptionBuilderService;

		public CurrentUserService(AuthenticationStateProvider AuthProv, IConnectionService connectionService, /*IUserService userService, */IExceptionBuilderService exceptionBuilderService)
		{
			_authProv = AuthProv;
			_connectionService = connectionService;
			//_userService = userService;
			_exceptionBuilderService = exceptionBuilderService;
		}

		public async Task<UserDT> GetCurrentUserAsync()
		{
			if (CurrentUser == null)
			{
				Console.WriteLine("enter get cur user");
				try
				{

					var claims = (await _authProv.GetAuthenticationStateAsync()).User.Claims;


					if (claims.Count() != 0)
					{
						var auth0Id = claims.Where(c => c.Type == "id").First().Value;

						CurrentUser = new UserDT();

						CurrentUser.FirstName = claims.Where(c => c.Type == "given_name").ToList().Count != 0 ? claims.Where(c => c.Type == "given_name").First().Value : "Unknown";
						CurrentUser.LastName = claims.Where(c => c.Type == "family_name").ToList().Count != 0 ? claims.Where(c => c.Type == "family_name").First().Value : "Unknown";
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

						try
						{
							var connection = await _connectionService.GetUserHubConnectionAsync();

							connection.On<UserDT>("GetCurrentUser", c => CurrentUser = c);

							await connection.InvokeAsync("GetCurrentUser", CurrentUser);
						}
						catch
						{
							throw;
						}


					}
					else throw _exceptionBuilderService.ParseException(ExceptionCodes.NotAuthentificatedUserException, nameof(CurrentUser));

				}
				catch
				{
					throw;
				}

			}

			return CurrentUser;
		}

		public async Task SetCurrentUser(UserDT user)
		{
			CurrentUser ??= user;
		}

	}
}
