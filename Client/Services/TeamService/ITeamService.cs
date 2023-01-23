using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.TeamService
{
    public interface ITeamService
    {
        Task<List<TeamDT>> GetAllTeamsAsync();
        Task<TeamDT> GetTeamByIdAsync(int id);
        Task<TeamDT> AddTeamAsync(TeamDT TeamDT);
        Task UpdateTeamAsync(int id);
        Task DeleteTeamAsync(int id);
    }
}
