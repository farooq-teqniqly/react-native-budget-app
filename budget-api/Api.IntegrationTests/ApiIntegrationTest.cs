namespace Api.IntegrationTests
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;
	using DataAccess.Entities;
	using FluentAssertions;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc.Testing;
	using Newtonsoft.Json.Linq;
	using Xunit;

	public class ApiIntegrationTest
    {
	    protected HttpClient GraphClient { get; }

	    protected ApiIntegrationTest()
	    {
		    var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
		    {
			    builder.UseEnvironment("ApiIntegrationTest");
		    });

		    this.GraphClient = factory.CreateClient();
		}
    }

	public class CategoriesIntegrationTest : ApiIntegrationTest
	{
		[Fact]
		public async Task Can_GetCategories()
		{
			var query = "query {categoryQuery {categories {id name}}}";
			var response = await this.GraphClient.PostAsync("/graphql", new StringContent(query, Encoding.UTF8, "application/graphql"));
			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var queryResult = JObject.Parse(await response.Content.ReadAsStringAsync());
			var jToken = queryResult["data"]!["categoryQuery"]!["categories"];
			var categories = jToken!.ToObject<IEnumerable<Category>>()!.ToList();
			
			categories.Count.Should().Be(3);

			categories.SingleOrDefault(c => c.Name == "Dining out")!.Id.Should().Be("5311D853-B5BA-4880-ADEF-9E8E1085A541");
			categories.SingleOrDefault(c => c.Name == "Groceries")!.Id.Should().Be("C89D1D44-8719-47F5-8AB5-5281D005DE3C");
			categories.SingleOrDefault(c => c.Name == "Net salary")!.Id.Should().Be("D715A5C6-C9A2-4FCC-AF03-781F684B9451");
		}

		[Fact]
		public async Task Can_Create_Get_Delete_Category()
		{
			var categoryName = nameof(this.Can_Create_Get_Delete_Category);
			var createMutation = "mutation {categoryMutation {createCategory(categoryInput:{name: " + "\"" + categoryName + "\"" + "}) {id name}}}";
			var createResponse = await this.GraphClient.PostAsync("/graphql", new StringContent(createMutation, Encoding.UTF8, "application/graphql"));
			createResponse.StatusCode.Should().Be(HttpStatusCode.OK);

			var queryResult = JObject.Parse(await createResponse.Content.ReadAsStringAsync());
			var jToken = queryResult["data"]!["categoryMutation"]!["createCategory"];
			var category = jToken!.ToObject<Category>();
			
			category!.Name.Should().Be(categoryName);
			category.Id.Should().NotBeEmpty();

			var deleteMutation = "mutation {categoryMutation {deleteCategory(categoryId: " + "\"" + category.Id + "\"" + ")}}";
			var deleteResponse = await this.GraphClient.PostAsync("/graphql", new StringContent(deleteMutation, Encoding.UTF8, "application/graphql"));
			deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

			queryResult = JObject.Parse(await deleteResponse.Content.ReadAsStringAsync());
			jToken = queryResult["data"]!["categoryMutation"]!["deleteCategory"];
			var deleteMessage = jToken!.ToObject<string>();

			deleteMessage.Should().Be("deleted");

		}
	}
}
