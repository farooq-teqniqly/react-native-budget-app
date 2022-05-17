// Copyright (c) Farooq Mahmud

namespace Api.IntegrationTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;
	using DataAccess.Entities;
	using FluentAssertions;
	using Newtonsoft.Json.Linq;
	using Xunit;

	public class CategoriesIntegrationTest : ApiIntegrationTest
	{
		[Fact]
		public async Task Can_GetCategories()
		{
			var query = "query {categoryQuery {categories {id name}}}";

			await this.RunTest<IEnumerable<Category>>(
				query,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"]!["categoryQuery"]!["categories"]!,
				(categories) =>
				{
					var enumerable = categories.ToList();

					enumerable.Count.Should().Be(3);
					enumerable.SingleOrDefault(c => c.Name == "Dining out")!.Id.Should().Be("5311D853-B5BA-4880-ADEF-9E8E1085A541");
					enumerable.SingleOrDefault(c => c.Name == "Groceries")!.Id.Should().Be("C89D1D44-8719-47F5-8AB5-5281D005DE3C");
					enumerable.SingleOrDefault(c => c.Name == "Net salary")!.Id.Should().Be("D715A5C6-C9A2-4FCC-AF03-781F684B9451");
				});
		}

		[Fact]
		public async Task Can_Create_Get_Delete_Category()
		{
			var categoryName = nameof(this.Can_Create_Get_Delete_Category);
			var createMutation = "mutation {categoryMutation {createCategory(categoryInput:{name: " + "\"" + categoryName + "\"" + "}) {id name}}}";
			
			var testResult = await this.RunTest<Category>(
				createMutation,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"]!["categoryMutation"]!["createCategory"],
				(category) =>
				{
					category!.Name.Should().Be(categoryName);
					category.Id.Should().NotBeEmpty();
				});

			
			var deleteMutation = "mutation {categoryMutation {deleteCategory(categoryId: " + "\"" + testResult.DeserializedResponse.Id + "\"" + ")}}";

			await this.RunTest<string>(
				deleteMutation,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"]!["categoryMutation"]!["deleteCategory"],
				(message) => message.Should().Be("deleted"));
		}
	}
}