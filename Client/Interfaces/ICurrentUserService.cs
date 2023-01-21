using SharedLib.DataTransferModels;

namespace BlazorWeb.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<UserDT> GetCurrentUserAsync();
        public Task SetCurrentUser(UserDT user);
    }
}
