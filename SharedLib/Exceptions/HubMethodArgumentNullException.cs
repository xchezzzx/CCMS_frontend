using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Exceptions
{
	internal class HubMethodArgumentNullException : ArgumentNullException
	{
		public HubMethodArgumentNullException(string message, int code) : base(message)
		{
			Code = code;
		}

		public int Code { get; }
	}
}
