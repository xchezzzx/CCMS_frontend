using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.UserService
{
    public interface IUserService
    {
        Task<UserDT> GetCurrentUserAsync(UserDT userDT);
        Task<List<UserDT>> GetAllUsersAsync();
        Task<UserDT> GetUserByIdAsync(int id);
        Task<UserDT> AddNewUserAsync(UserDT userDT);
        Task UpdateUserAsync(int id);
        Task DeleteUserAsync(int id);
    }
}
