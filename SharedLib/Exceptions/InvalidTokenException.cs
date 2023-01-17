using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Exceptions
{
	internal class InvalidTokenException : Exception
	{
		public int ErrorCode { get; }

		public InvalidTokenException(string message, int errorCode) : base(message)
		{
			ErrorCode = errorCode;
		}
	}
}
