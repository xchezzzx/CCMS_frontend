using BlazorWeb.Models.DataTransferModels;

namespace BlazorWeb.Interfaces
{
	public interface IUserService
	{
		Task<List<UserDT>> GetAllUsersAsync();
		Task<UserDT> GetUserByIdAsync(int id);
		Task AddUser(UserDT userDT);
		Task UpdateUser(int id);
		Task DeleteUser(int id);
	}
}
