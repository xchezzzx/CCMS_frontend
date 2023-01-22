using SharedLib.Constants.Enums;
using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.UserService
{
    public interface IUserService
    {
        Task<UserDT> GetCurrentUserAsync(UserDT userDT);
		Task<UserDT> AddNewUserAsync(UserDT userDT);
		Task<List<UserDT>> GetAllUsersAsync();
		Task<List<UserDT>> GetAllActiveUsersAsync();
		Task<string> UpdateUserAsync(UserDT userDT);
		Task<string> DeleteUserByIdAsync(int userId);
		Task<UserDT> GetUserByIdAsync(int id);
		Task<string> AssignRoleToUser(int userId, Roles role);
	}
}
