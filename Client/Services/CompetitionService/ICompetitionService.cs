using SharedLib.DataTransferModels;

namespace BlazorWeb.Services.CompetitionService
{
    public interface ICompetitionService
    {
        //COMPETITIONS - base operations
        Task<CompetitionDT> AddNewCompetitionAsync(CompetitionDT competitionDT);
        Task<CompetitionDT> GetCompetitionByIdAsync(int competitionId);
        Task<List<CompetitionDT>> GetAllCompetitionsAsync();
        Task<List<CompetitionDT>> GetAllActiveCompetitionsAsync();
        Task<string> UpdateCompetitionAsync(CompetitionDT competitionDT);
        Task<string> DeleteCompetitionByIdAsync(int competitionId);

        //COMPETITIONS - lifecycle
        Task<string> DisableCompetitionByIdAsync(int competitionId);
        Task<string> StartCompetitionByIdAsync(int competitionId);
        Task<string> EndCompetitionByIdAsync(int competitionId);

        //OPERATORS
        Task<string> AddNewOperatorToCompetitionAsync(int competitionId, int operatorId);
        Task<string> RemoveOperatorFromCompetitionAsync(int competitionId, int operatorId);
        Task<List<UserDT>> GetAllCompetitionOperatorsAsync(int competitionId);

        //EXERCISES
        Task<string> AddNewExerciseToCompetitionAsync(int competitionId, int exerciseId);
        Task<string> RemoveExerciseFromCompetitionAsync(int competitionId, int exerciseId);
        Task<List<ExerciseDT>> GetAllCompetitionExercisesAsync();

        //TEAMS
        Task<string> AddNewTeamToCompetitionAsync(int competitionId, int teamId);
        Task<string> RemoveTeamFromCompetitionAsync(int competitionId, int teamId);
        Task<List<TeamDT>> GetAllCompetitionTeamsAsync(int competitionId);

        //PARTICIPANTS
        Task<List<UserDT>> GetAllCompetitionParticipantsAsync();
    }
}
