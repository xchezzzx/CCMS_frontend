using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.TeamService
{
    public interface ITeamService
    {
        Task<List<TeamDT>> GetAllTeamsAsync();
        Task<TeamDT> GetTeamByIdAsync(int id);
        Task<string> AddTeamAsync(TeamDT TeamDT);
        Task UpdateTeamAsync(int id);
        Task DeleteTeamAsync(int id);
    }
}
