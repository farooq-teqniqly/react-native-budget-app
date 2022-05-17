// Copyright (c) Farooq Mahmud

namespace Api.IntegrationTests
{
	using System;
	using System.Net.Http;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc.Testing;
	using Newtonsoft.Json.Linq;

	public class ApiIntegrationTest
	{
		protected ApiIntegrationTest()
		{
			var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
			{
				builder.UseEnvironment("ApiIntegrationTest");
			});

			this.GraphClient = factory.CreateClient();
		}

		protected HttpClient GraphClient { get; }

		protected async Task RunTest<T>(
			string query,
			Action<HttpResponseMessage> assertResponse,
			Func<JObject, JToken> objectToDeserialize,
			Action<T> assertDeserializedResponse)
		{
			var response = await this.GraphClient.SendQueryAsync(query);
			assertResponse(response);
			var deserializedResponse = await response.DeserializeRepsonse<T>(objectToDeserialize);
			assertDeserializedResponse(deserializedResponse);
		}
	}
}
