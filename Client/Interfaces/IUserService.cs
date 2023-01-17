using SharedLib.DataTransferModels;

namespace BlazorWeb.Interfaces
{
	public interface IUserService
	{
		Task<List<UserDT>> GetAllUsersAsync();
		Task<UserDT> GetUserByIdAsync(int id);
		Task AddUserAsync(UserDT userDT);
		Task UpdateUserAsync(int id);
		Task DeleteUserAsync(int id);
	}
}
