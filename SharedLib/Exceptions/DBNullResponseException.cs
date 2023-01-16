namespace SharedLib.Exceptions
{
	public class DBNullResponseException : Exception
	{
		public DBNullResponseException(string message, int code) : base(message)
		{
			Code = code;
		}

		public int Code { get; }
	}
}
