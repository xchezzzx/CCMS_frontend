using SharedLib.Exceptions;
using SharedLib.Constants.Enums;

namespace SharedLib.Services.ExceptionBuilderService
{
	public class ExceptionBuilderService : IExceptionBuilderService
	{
		public Exception ParseException(ExceptionCodes exceptionCode, params object[] args)
		{
			switch (exceptionCode)
			{
				case ExceptionCodes.DBNullResponseException:
					return new DBNullResponseException
					(
						$"Exception {(int)ExceptionCodes.DBNullResponseException}. Database returned null value at {args[0]}.", 
						(int)ExceptionCodes.DBNullResponseException
					);

				case ExceptionCodes.DBUpdateException:
					return new DBUpdateException($"Exception {(int)ExceptionCodes.DBUpdateException}. Database save chsnges error at {args[0]}.", (int)ExceptionCodes.DBUpdateException);

				case ExceptionCodes.ArgumentNullException:
					return new ArgumentNullException($"Exception {(int)ExceptionCodes.DBUpdateException}. Null argument at {args[0]}.");

				case ExceptionCodes.HubMethodNullArgumentException:
					return new HubMethodArgumentNullException($"Exception {(int)ExceptionCodes.DBUpdateException}. Null argument in Hub method at {args[0]}.", (int)ExceptionCodes.HubMethodNullArgumentException);
				case ExceptionCodes.DBNoDataFoundException:
					return new DBNoDataFoundException($"Exception {(int)ExceptionCodes.DBUpdateException}. No data found in database at {args[0]}.", (int)ExceptionCodes.DBNoDataFoundException);
                case ExceptionCodes.NotAuthentificatedUserException:
                    return new NotAuthenticatedUserException($"Exception {(int)ExceptionCodes.NotAuthentificatedUserException}. User is not authentificate {args[0]}.", (int)ExceptionCodes.NotAuthentificatedUserException);
                default:
					return new Exception("An unknown error has occurred.");
			}
		}
	}

}
