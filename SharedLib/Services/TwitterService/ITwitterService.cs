using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Services.TwitterService
{
	public  interface ITwitterService
	{
		Task TweetAsync(string content);
	}
}
