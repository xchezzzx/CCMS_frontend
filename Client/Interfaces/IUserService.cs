using SharedLib.DataTransferModels;

namespace BlazorWeb.Interfaces
{
	public interface IUserService
	{
		Task<UserDT> GetCurrentUserAsync(string auth0Id);
		Task<List<UserDT>> GetAllUsersAsync();
		Task<UserDT> GetUserByIdAsync(int id);
		Task<UserDT> AddNewUserAsync(UserDT userDT);
		Task UpdateUserAsync(int id);
		Task DeleteUserAsync(int id);
	}
}
