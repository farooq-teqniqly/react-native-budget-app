// Copyright (c) Farooq Mahmud

namespace Api.IntegrationTests
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Threading.Tasks;
	using DataAccess.Entities;
	using FluentAssertions;
	using Xunit;

	public class PayeeIntegrationTests : ApiIntegrationTest
	{
		[Fact]
		public async Task Can_GetPayees()
		{
			var query = "query {payeeQuery {payees {id name}}}";

			await this.RunTest<IEnumerable<Payee>>(
				query,
				(response) => response.StatusCode.Should().Be(HttpStatusCode.OK),
				(jo) => jo["data"] !["payeeQuery"] !["payees"] !,
				(payees) =>
				{
					var enumerable = payees.ToList();

					enumerable.Count.Should().Be(4);
					enumerable.SingleOrDefault(c => c.Name == "ACME Widgets") !.Id.Should().Be("17FC72D5-C08F-4452-8CF4-395D40C83837");
					enumerable.SingleOrDefault(c => c.Name == "Denny's") !.Id.Should().Be("682EBC46-C7BB-4F1C-AEF0-B6A00691279A");
					enumerable.SingleOrDefault(c => c.Name == "Jill") !.Id.Should().Be("44186C12-C48C-40BA-850E-6B4CC153F86A");
					enumerable.SingleOrDefault(c => c.Name == "Safeway") !.Id.Should().Be("8AE49976-52F5-45E9-B6F9-72D2E4DAACBF");
				});
		}

		[Fact]
		public async Task Can_Create_And_Delete_Payee()
		{
			var payeeName = nameof(this.Can_Create_And_Delete_Payee);

			var createMutation = $@"mutation {{
									  payeeMutation {{
									    createPayee(payeeInput:{{name:""{payeeName}""}}) {{
									      id
									      name
									    }}
									  }}
									}}";

			var testResult = await this.RunTest<Payee>(
				createMutation,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["payeeMutation"] !["createPayee"] !,
				(payee) =>
				{
					payee.Name.Should().Be(payeeName);
					payee.Id.Should().NotBeEmpty();
				});

			var deleteMutation = $@"mutation deletePayee {{
									  payeeMutation {{
									    deletePayee(payeeId: ""{testResult.DeserializedResponse.Id}"")
									  }}
									}}";

			await this.RunTest<string>(
				deleteMutation,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["payeeMutation"] !["deletePayee"] !,
				(message) => message.Should().Be("deleted"));
		}
	}
}
