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
        Task UpdateCompetitionAsync(CompetitionDT competitionDT);
        Task DeleteCompetitionByIdAsync(int competitionId);

        //COMPETITIONS - lifecycle
        Task DisableCompetitionByIdAsync(int competitionId);
        Task StartCompetitionByIdAsync(int competitionId);
        Task EndCompetitionByIdAsync(int competitionId);

        //OPERATORS
        Task AddNewOperatorToCompetitionAsync(int competitionId, int operatorId);
		Task AddNewOperatorsToCompetitionAsync(int competitionId, List<int?> operatorIds);

		Task RemoveOperatorFromCompetitionAsync(int competitionId, int operatorId);
        Task<List<UserDT>> GetAllCompetitionOperatorsAsync(int competitionId);

        //EXERCISES
        Task AddNewExerciseToCompetitionAsync(int competitionId, int exerciseId);
		Task AddNewExercisesToCompetitionAsync(int competitionId, List<int?> excerciseIds);

		Task RemoveExerciseFromCompetitionAsync(int competitionId, int exerciseId);
        Task<List<ExerciseDT>> GetAllCompetitionExercisesAsync(int competitionId);

        //TEAMS
        Task AddNewTeamToCompetitionAsync(int competitionId, int teamId);
		Task AddNewTeamsToCompetitionAsync(int competitionId, List<int?> teamIds);

		Task RemoveTeamFromCompetitionAsync(int competitionId, int teamId);
        Task<List<TeamDT>> GetAllCompetitionTeamsAsync(int competitionId);

        //PARTICIPANTS
        Task<List<UserDT>> GetAllCompetitionParticipantsAsync();
    }
}
