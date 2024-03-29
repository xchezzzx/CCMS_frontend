﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Exceptions
{
	internal class DBNoDataFoundException : Exception
	{
		public DBNoDataFoundException(string message, int code) : base(message)
		{
			Code = code;
		}
		public int Code { get; }
	}
}
