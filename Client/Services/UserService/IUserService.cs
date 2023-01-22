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
		Task UpdateUserAsync(UserDT userDT, int userUpdateId);
		Task DeleteUserByIdAsync(int userId, int userUpdateId);
		Task<UserDT> GetUserByIdAsync(int id);
		Task AssignRoleToUser(int userId, Roles role, int userUpdateId);
	}
}
