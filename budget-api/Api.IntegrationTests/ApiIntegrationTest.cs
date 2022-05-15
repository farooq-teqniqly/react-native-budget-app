namespace Api.IntegrationTests
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Net.Http.Json;
	using System.Runtime.CompilerServices;
	using System.Text;
	using System.Threading.Tasks;
	using DataAccess.Entities;
	using FluentAssertions;
	using Microsoft.AspNetCore.Mvc.Testing;
	using Microsoft.Extensions.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Xunit;

	public class ApiIntegrationTest
    {
	    protected HttpClient GraphClient { get; }

	    protected ApiIntegrationTest()
	    {
		    var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
		    this.GraphClient = factory.CreateClient();
		}
    }

	public class CategoriesIntegrationTest : ApiIntegrationTest
	{
		[Fact]
		public async Task CanGetCategories()
		{
			var query = "query getLedgers {\r\n  ledgerQuery {\r\n    ledgers {\r\n      name\r\n      id\r\n      created\r\n    }\r\n  }\r\n}";
			var response = await this.GraphClient.PostAsync("/graphql", new StringContent(query, Encoding.UTF8, "application/graphql"));
			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var queryResult = JObject.Parse(await response.Content.ReadAsStringAsync());
			var ledgerJToken = queryResult["data"]!["ledgerQuery"]!["ledgers"];
			var ledgers = ledgerJToken!.ToObject<IEnumerable<Ledger>>();

		}

		[Fact]
		public async Task Can_Create_Get_Delete_Category()
		{

		}
	}
}
