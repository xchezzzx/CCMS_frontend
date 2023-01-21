using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.CurrentUserService
{
    public interface ICurrentUserService
    {
        public Task<UserDT> GetCurrentUserAsync();
        public Task SetCurrentUser(UserDT user);
    }
}
