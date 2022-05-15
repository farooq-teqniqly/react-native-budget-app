// Copyright (c) Farooq Mahmud

namespace Api.IntegrationTests
{
	using System.Net.Http;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc.Testing;

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
	}
}
