using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Services.TwitterService
{
	public class TwitterService : ITwitterService
	{
		public async Task TweetAsync(string content)
		{
			var client = new HttpClient();

			var requestBody = new
			{
				content = content,
			};

			var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:6060/twit/")
			{
				Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
			};

			var response = await client.SendAsync(request);

		}
	}
}
