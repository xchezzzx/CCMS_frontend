using SharedLib.Constants.Enums;
using SharedLib.Exceptions;

namespace SharedLib.Services.ExceptionBuilderService
{
    public interface IExceptionBuilderService 
    {
        Exception ParseException(ExceptionCodes exceptionCode, params object[] args);
	}
}
