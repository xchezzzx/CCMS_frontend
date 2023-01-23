using SharedLib.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorWeb.Services.CurrentUserService;
using BlazorWeb.Services.ConnectionService;

namespace BlazorWeb.Services.CompetitionService
{
    public class CompetitionService : ICompetitionService
    {
        IAccessTokenProvider _accessTokenProvider;


        private readonly IConnectionService _connectionService;


        public CompetitionService(IAccessTokenProvider accessTokenProvider, IConnectionService connectionService)
        {
            _accessTokenProvider = accessTokenProvider;
            _connectionService = connectionService;
        }

        //COMPETITIONS - basic operations
        public async Task<CompetitionDT> AddNewCompetitionAsync(CompetitionDT competitionDT)
        {
            CompetitionDT newCompetition = new();

            //HubConnection connection = new HubConnectionBuilder()
            //					.WithUrl("https://localhost:7206/competitions")
            //					.WithAutomaticReconnect()
            //					.Build();


            var _connection = await _connectionService.GetCompetitionHubConnectionAsync();

            _connection.On<CompetitionDT>(
                "AddNewCompetition", c => newCompetition = c);

            await _connection.StartAsync();
            try
            {
                await _connection.InvokeAsync("AddNewCompetition", competitionDT);

            }
            catch 
            {

                throw;
            }
            await _connection.StopAsync();

            return newCompetition;
        }

        public async Task<CompetitionDT> GetCompetitionByIdAsync(int competitionId)
        {
            CompetitionDT _getCompetition = new();

            //HubConnection HubConnection = new HubConnectionBuilder()
            //							.WithUrl("https://localhost:7206/competitions")
            //							.Build();


            var _connection = await _connectionService.GetCompetitionHubConnectionAsync();
            _connection.On<CompetitionDT>("GetCompetitionById", c => _getCompetition = c);

			await _connection.StartAsync();

			try
			{
			    await _connection.InvokeAsync("GetCompetitionById", competitionId);

			}
			catch
			{

				throw;
			}
			await _connection.StopAsync();

			return _getCompetition;
        }

        public async Task<List<CompetitionDT>> GetAllCompetitionsAsync()
        {
            List<CompetitionDT> _getAllCompetitions = new();

            HubConnection HubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .Build();

            HubConnection.On<List<CompetitionDT>>("GetAllCompetitions", c => _getAllCompetitions = c);

            await HubConnection.StartAsync();

			try
			{
			    await HubConnection.InvokeAsync("GetAllCompetitions");

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

            return _getAllCompetitions;
        }

        public async Task<List<CompetitionDT>> GetAllActiveCompetitionsAsync()
        {
            List<CompetitionDT> _getAllActiveCompetitions = new();

            var accessTokenResult = await _accessTokenProvider.RequestAccessToken();
            var _AccessToken = string.Empty;

            if (accessTokenResult.TryGetToken(out var token))
            {
                _AccessToken = token.Value;
            }


            HubConnection _connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions", o =>
                            {
                                o.AccessTokenProvider = () => Task.FromResult(_AccessToken);
                            })
                            .Build();



            _connection.On<List<CompetitionDT>>("GetActiveCompetitions", c => _getAllActiveCompetitions = c);

            await _connection.StartAsync();

			try
			{
			    await _connection.InvokeAsync("GetActiveCompetitions");
			}
			catch
			{

				throw;
			}
            await _connection.StopAsync();

            return _getAllActiveCompetitions;
        }

        public async Task UpdateCompetitionAsync(CompetitionDT competitionDT)
        {

            HubConnection HubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .Build();


            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("GetAllActiveCompetitions", competitionDT);

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

        }

        public async Task DeleteCompetitionByIdAsync(int competitionId)
        {

            HubConnection HubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .Build();


            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("DeleteCompetitionById", competitionId);

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

        }

        //COMPETITIONS - lifecycle
        public async Task DisableCompetitionByIdAsync(int competitionId)
        {

            HubConnection HubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .Build();


            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("DisableCompetitionById", competitionId);

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

        }

        public async Task StartCompetitionByIdAsync(int competitionId)
        {

            HubConnection HubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .Build();


            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("StartCompetitionById", competitionId);

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

        }

        public async Task EndCompetitionByIdAsync(int competitionId)
        {

            HubConnection HubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .Build();


            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("EndCompetitionById", competitionId);

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

        }

        //OPERATORS
        public async Task AddNewOperatorToCompetitionAsync(int competitionId, int operatorId)
        {
            string messageFromServer = string.Empty;

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();


            await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("AddNewOperatorToCompetition", competitionId, operatorId);

			}
			catch
			{

				throw;
			}
            await connection.StopAsync();

        }
		public async Task AddNewOperatorsToCompetitionAsync(int competitionId, List<int?> operatorIds)
		{

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();



			await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("AddNewOperatorsToCompetition", competitionId, operatorIds);

			}
			catch
			{

				throw;
			}
			await connection.StopAsync();

		}

		public async Task RemoveOperatorFromCompetitionAsync(int competitionId, int operatorId)
        {

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();


            await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("RemoveOperatorFromCompetition", competitionId, operatorId);

			}
			catch
			{

				throw;
			}
            await connection.DisposeAsync();

        }

        public async Task<List<UserDT>> GetAllCompetitionOperatorsAsync(int competitionId)
        {

            List<UserDT> _getAllCompetitionOperators = new();

            HubConnection HubConnection = new HubConnectionBuilder()
                                .WithUrl("https://localhost:7206/competitions")
                                .Build();

            HubConnection.On<List<UserDT>>("GetAllCompetitionOperators", c => _getAllCompetitionOperators = c);

            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("GetAllCompetitionOperators", competitionId);

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

            return _getAllCompetitionOperators;
        }

        //EXERCISES
        public async Task AddNewExerciseToCompetitionAsync(int competitionId, int exerciseId)
        {
            string messageFromServer = string.Empty;

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();


            await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("AddNewExerciseToCompetition", competitionId, exerciseId);

			}
			catch
			{

				throw;
			}
            await connection.DisposeAsync();

        }

		public async Task AddNewExercisesToCompetitionAsync(int competitionId, List<int?> excerciseIds)
		{
			string messageFromServer = string.Empty;

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();



			await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("AddNewExercisesToCompetition", competitionId, excerciseIds);

			}
			catch
			{

				throw;
			}
			await connection.DisposeAsync();

		}


		public async Task RemoveExerciseFromCompetitionAsync(int competitionId, int exerciseId)
        {

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();

            await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("RemoveExerciseFromCompetition", competitionId, exerciseId);

			}
			catch
			{

				throw;
			}
            await connection.DisposeAsync();

        }

        public async Task<List<ExerciseDT>> GetAllCompetitionExercisesAsync(int competitionId)
        {
            List<ExerciseDT> _getAllCompetitionExercises = new();

            HubConnection HubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .Build();

            HubConnection.On<List<ExerciseDT>>("GetAllCompetitionExercises", c => _getAllCompetitionExercises = c);

            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("GetAllCompetitionExercises", competitionId);

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

            return _getAllCompetitionExercises;
        }

        //TEAMS
        //ADD NEW TEAM
        public async Task AddNewTeamToCompetitionAsync(int competitionId, int teamId)
        {

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();

            await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("AddNewTeamToCompetition", competitionId, teamId);

			}
			catch
			{

				throw;
			}
            await connection.DisposeAsync();
        }

		public async Task AddNewTeamsToCompetitionAsync(int competitionId, List<int?> teamIds)
		{

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();

			await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("AddNewTeamsToCompetition", competitionId, teamIds);

			}
			catch
			{

				throw;
			}
			await connection.DisposeAsync();

		}


		public async Task RemoveTeamFromCompetitionAsync(int competitionId, int teamId)
        {

            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:7206/competitions")
                            .WithAutomaticReconnect()
                            .Build();


            await connection.StartAsync();
			try
			{
			    await connection.InvokeAsync("RemoveTeamFromCompetition", competitionId, teamId);

			}
			catch
			{

				throw;
			}
            await connection.DisposeAsync();

        }

        public async Task<List<TeamDT>> GetAllCompetitionTeamsAsync(int competitionId)
        {
            List<TeamDT> _getAllCompetitionTeams = new();

            HubConnection HubConnection = new HubConnectionBuilder()
                                .WithUrl("https://localhost:7206/competitions")
                                .Build();

            HubConnection.On<List<TeamDT>>("GetAllCompetitionTeams", c => _getAllCompetitionTeams = c);

            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("GetAllCompetitionTeams", competitionId);

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

            return _getAllCompetitionTeams;
        }

        //PARTICIPANTS
        public async Task<List<UserDT>> GetAllCompetitionParticipantsAsync()
        {
            List<UserDT> _getAllCompetitionParticipants = new();
            HubConnection HubConnection = new HubConnectionBuilder()
                                .WithUrl("https://localhost:7206/competitions")
                                .Build();

            HubConnection.On<List<UserDT>>("GetAllCompetitionParticipants", c => _getAllCompetitionParticipants = c);

            await HubConnection.StartAsync();
			try
			{
			    await HubConnection.InvokeAsync("GetAllCompetitionParticipants");

			}
			catch
			{

				throw;
			}
            await HubConnection.StopAsync();

            return _getAllCompetitionParticipants;
        }
    }

}
