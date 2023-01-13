using BlazorWeb.Models.DataTransferModels;

namespace BlazorWeb.Interfaces
{
    public interface ICompetitionService
    {
        Task<List<CompetitionDT>> GetAllCompetitionsAsync();
        //Task<CompetitionDT> GetCompetitionByIdAsync(int id);
        //Task AddCompetitionAsync(CompetitionDT competitionDT);
        //Task UpdateCompetitionAsync(CompetitionDT competitionDT);
        //Task DeleteCompetitionAsync(int id);
        
    }
}
