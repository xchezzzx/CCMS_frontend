using SharedLib.DataTransferModels;

namespace BlazorWeb.Interfaces
{
    public interface ICompetitionService
    {
        Task<List<CompetitionDT>> GetAllCompetitionsAsync();
        Task<CompetitionDT> GetCompetitionByIdAsync(int id);
        Task<string> AddCompetitionAsync(CompetitionDT competitionDT);
        Task UpdateCompetitionAsync(CompetitionDT competitionDT);
        Task DeleteCompetitionAsync(int id);
		Task<List<UserDT>> GetAllOperatorsAsync();

		Task AddOperatorToCompetitionAsync(int id);
    }
}
