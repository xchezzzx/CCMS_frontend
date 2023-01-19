using BlazorWeb.Interfaces;
using SharedLib.DataTransferModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWeb.Services
{
	public class CompetitionService : ICompetitionService
	{
		public CompetitionService()
		{

		}

		//COMPETITIONS - basic operations
		public async Task<CompetitionDT> AddNewCompetitionAsync(CompetitionDT competitionDT)
		{
			CompetitionDT newCompetition = new();

			HubConnection connection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/competitions")
								.WithAutomaticReconnect()
								.Build();

			connection.On<CompetitionDT> (
				"AddNewCompetition", c => newCompetition = c);

			await connection.StartAsync();
			await connection.InvokeAsync("AddNewCompetition", competitionDT);
			await connection.DisposeAsync();

			return newCompetition;
		}

		public async Task<CompetitionDT> GetCompetitionByIdAsync(int competitionId)
		{
			CompetitionDT _getCompetition = new();

			HubConnection HubConnection = new HubConnectionBuilder()
										.WithUrl("https://localhost:7206/competitions")
										.Build();

			HubConnection.On<CompetitionDT>("GetCompetitionById", c => _getCompetition = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetCompetitionById", competitionId);
			await HubConnection.StopAsync();

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
			await HubConnection.InvokeAsync("GetAllCompetitions");
			await HubConnection.StopAsync();

			return _getAllCompetitions;
		}

		public async Task<List<CompetitionDT>> GetAllActiveCompetitionsAsync()
		{
			List<CompetitionDT> _getAllActiveCompetitions = new();

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.Build();

			HubConnection.On<List<CompetitionDT>>("GetActiveCompetitions", c => _getAllActiveCompetitions = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetActiveCompetitions");
			await HubConnection.StopAsync();

			return _getAllActiveCompetitions;
		}

		public async Task<string> UpdateCompetitionAsync(CompetitionDT competitionDT)
		{
			string messageFromServer = string.Empty;

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.Build();

			HubConnection.On<string>("GetAllActiveCompetitions", msg =>
			{ 
				messageFromServer = msg;
			});

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllActiveCompetitions", competitionDT);
			await HubConnection.StopAsync();

			return messageFromServer;
		}

		public async Task<string> DeleteCompetitionByIdAsync(int competitionId)
		{
			string messageFromServer = string.Empty;

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.Build();

			HubConnection.On<string>("DeleteCompetitionById", msg =>
			{
				messageFromServer = msg;
			});

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("DeleteCompetitionById", competitionId);
			await HubConnection.StopAsync();

			return messageFromServer;
		}

		//COMPETITIONS - lifecycle
		public async Task<string> DisableCompetitionByIdAsync(int competitionId)
		{
			string messageFromServer = string.Empty;

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.Build();

			HubConnection.On<string>("DisableCompetitionById", msg =>
			{
				messageFromServer = msg;
			});

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("DisableCompetitionById", competitionId);
			await HubConnection.StopAsync();

			return messageFromServer;
		}

		public async Task<string> StartCompetitionByIdAsync(int competitionId)
		{
			string messageFromServer = string.Empty;

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.Build();

			HubConnection.On<string>("StartCompetitionById", msg =>
			{
				messageFromServer = msg;
			});

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("StartCompetitionById", competitionId);
			await HubConnection.StopAsync();

			return messageFromServer;
		}

		public async Task<string> EndCompetitionByIdAsync(int competitionId)
		{
			string messageFromServer = string.Empty;

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.Build();

			HubConnection.On<string>("EndCompetitionById", msg =>
			{
				messageFromServer = msg;
			});

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("EndCompetitionById", competitionId);
			await HubConnection.StopAsync();

			return messageFromServer;
		}

		//OPERATORS
		public async Task<string> AddNewOperatorToCompetitionAsync(int competitionId, int operatorId)
		{
			string messageFromServer = string.Empty;

			HubConnection connection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.WithAutomaticReconnect()
							.Build();

			connection.On<string>("AddNewOperatorToCompetition", msg =>
			{
				messageFromServer = msg;
			});

			await connection.StartAsync();
			await connection.InvokeAsync("AddNewOperatorToCompetition", competitionId, operatorId);
			await connection.DisposeAsync();

			return messageFromServer;
		}

		public async Task<string> RemoveOperatorFromCompetitionAsync(int competitionId, int operatorId)
		{
			string messageFromServer = string.Empty;

			HubConnection connection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.WithAutomaticReconnect()
							.Build();

			connection.On<string>("RemoveOperatorFromCompetition", msg =>
			{
				messageFromServer = msg;
			});

			await connection.StartAsync();
			await connection.InvokeAsync("RemoveOperatorFromCompetition", competitionId, operatorId);
			await connection.DisposeAsync();

			return messageFromServer;
		}

		public async Task<List<UserDT>> GetAllCompetitionOperatorsAsync(int competitionId)
		{

			List<UserDT> _getAllCompetitionOperators = new();

			HubConnection HubConnection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/competitions")
								.Build();

			HubConnection.On<List<UserDT>>("GetAllCompetitionOperators", c => _getAllCompetitionOperators = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllCompetitionOperators", competitionId);
			await HubConnection.StopAsync();

			return _getAllCompetitionOperators;
		}

		//EXERCISES
		public async Task<string> AddNewExerciseToCompetitionAsync(int competitionId, int exerciseId)
		{
			string messageFromServer = string.Empty;

			HubConnection connection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.WithAutomaticReconnect()
							.Build();

			connection.On<string>("AddNewExerciseToCompetition", msg =>
			{
				messageFromServer = msg;
			});

			await connection.StartAsync();
			await connection.InvokeAsync("AddNewExerciseToCompetition", competitionId, exerciseId);
			await connection.DisposeAsync();

			return messageFromServer;
		}

		public async Task<string> RemoveExerciseFromCompetitionAsync(int competitionId, int exerciseId)
		{
			string messageFromServer = string.Empty;

			HubConnection connection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.WithAutomaticReconnect()
							.Build();

			connection.On<string>("RemoveExerciseFromCompetition", msg =>
			{
				messageFromServer = msg;
			});

			await connection.StartAsync();
			await connection.InvokeAsync("RemoveExerciseFromCompetition", competitionId, exerciseId);
			await connection.DisposeAsync();

			return messageFromServer;
		}

		public async Task<List<ExerciseDT>> GetAllCompetitionExercisesAsync()
		{
			List<ExerciseDT> _getAllCompetitionExercises = new();

			HubConnection HubConnection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.Build();

			HubConnection.On<List<ExerciseDT>>("GetAllCompetitionExercises", c => _getAllCompetitionExercises = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllCompetitionExercises");
			await HubConnection.StopAsync();

			return _getAllCompetitionExercises;
		}

		//TEAMS
		public async Task<string> AddNewTeamToCompetitionAsync(int competitionId, int teamId)
		{
			string messageFromServer = string.Empty;

			HubConnection connection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.WithAutomaticReconnect()
							.Build();

			connection.On<string>("AddNewTeamToCompetition", msg =>
			{
				messageFromServer = msg;
			});

			await connection.StartAsync();
			await connection.InvokeAsync("AddNewTeamToCompetition", competitionId, teamId);
			await connection.DisposeAsync();

			return messageFromServer;
		}

		public async Task<string> RemoveTeamFromCompetitionAsync(int competitionId, int teamId)
		{
			string messageFromServer = string.Empty;

			HubConnection connection = new HubConnectionBuilder()
							.WithUrl("https://localhost:7206/competitions")
							.WithAutomaticReconnect()
							.Build();

			connection.On<string>("RemoveTeamFromCompetition", msg =>
			{
				messageFromServer = msg;
			});

			await connection.StartAsync();
			await connection.InvokeAsync("RemoveTeamFromCompetition", competitionId, teamId);
			await connection.DisposeAsync();

			return messageFromServer;
		}

		public async Task<List<TeamDT>> GetAllCompetitionTeamsAsync(int competitionId)
		{
			List<TeamDT> _getAllCompetitionTeams = new();

			HubConnection HubConnection = new HubConnectionBuilder()
								.WithUrl("https://localhost:7206/competitions")
								.Build();

			HubConnection.On<List<TeamDT>>("GetAllCompetitionTeams", c => _getAllCompetitionTeams = c);

			await HubConnection.StartAsync();
			await HubConnection.InvokeAsync("GetAllCompetitionTeams", competitionId);
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
			await HubConnection.InvokeAsync("GetAllCompetitionParticipants");
			await HubConnection.StopAsync();

			return _getAllCompetitionParticipants;
		}
	}

}
