namespace BlazorWeb.Enums
{
	public enum EntityStatuses : short
	{
		Active = 1,
		Inactive = 2
	}

	public enum Roles
	{
		Administrator = 1,
		Operator,
		Participant,
		Observer
	}

	public enum CompetitionStates
	{
		Planned = 1,
		InProgress = 2,
		Ended = 3,
		Canceled = 4,
		Dropped = 5
	}

	public enum ExerciseStates
	{
		NotTaken = 1,
		Taken = 2,
		Solved = 3,
		Submitted = 4,
		Approved = 5,
		Declined = 6,
		dropped = 7,
		disabled = 8
	}
}
