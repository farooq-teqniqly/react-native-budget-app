namespace Api.IntegrationTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;
	using Newtonsoft.Json.Linq;

	public static class HttpClientExtensions
	{
		public static async Task<HttpResponseMessage> SendQueryAsync(this HttpClient httpClient, string query)
		{
			return await httpClient.PostAsync(
				"/graphql",
				new StringContent(
					query,
					Encoding.UTF8,
					"application/graphql"));
		}

		public static async Task<T> DeserializeRepsonse<T>(
			this HttpResponseMessage response,
			Func<JObject, JToken> objectToDeserialize)
		{
			var queryResult = JObject.Parse(await response.Content.ReadAsStringAsync());
			var indexedQueryResultToken = objectToDeserialize(queryResult);
			return indexedQueryResultToken.ToObject<T>() !;
		}
	}
}
