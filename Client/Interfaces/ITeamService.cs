using SharedLib.DataTransferModels;

namespace BlazorWeb.Interfaces
{
	public interface ITeamService
	{
		Task<List<TeamDT>> GetAllTeamsAsync();
		Task<TeamDT> GetTeamByIdAsync(int id);
		Task AddTeam(TeamDT TeamDT);
		Task UpdateTeam(int id);
		Task DeleteTeam(int id);
	}
}
