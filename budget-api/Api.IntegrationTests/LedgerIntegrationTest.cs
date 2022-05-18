// Copyright (c) Farooq Mahmud

namespace Api.IntegrationTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Threading.Tasks;
	using DataAccess.Entities;
	using FluentAssertions;
	using Xunit;

	public class LedgerIntegrationTest : ApiIntegrationTest
	{
		[Fact]
		public async Task Can_GetLedgers()
		{
			var query = @"query {
							  ledgerQuery {
							    ledgers {
							      id
							      name
							    }
							  }
							}";

			await this.RunTest<IEnumerable<Ledger>>(
				query,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["ledgerQuery"] !["ledgers"] !,
				(ledgers) =>
				{
					var enumerable = ledgers.ToList();

					enumerable.Count.Should().Be(1);
					enumerable.SingleOrDefault(c => c.Name == "Demo Ledger") !.Id.Should().Be("6A58E91A-EC0D-447B-B958-0E0210208176");
				});
		}

		[Fact]
		public async Task Can_GetLedger()
		{
			var ledgerId = "6A58E91A-EC0D-447B-B958-0E0210208176";

			var query = $@"query {{
							  ledgerQuery {{
							    ledger(ledgerId: ""{ledgerId}"") {{
							      id
							      name
								  created
								  lastUpdated
							    }}
							  }}
							}}";

			await this.RunTest<Ledger>(
				query,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["ledgerQuery"] !["ledger"] !,
				(ledger) =>
				{
					ledger.Id.Should().Be(ledgerId);
					ledger.Name.Should().Be("Demo Ledger");
					ledger.Created.Should().Be(DateTime.Parse("2022-05-10 00:00:00.0000000"));
					ledger.LastUpdated.Should().Be(default(DateTime));
				});
		}

		[Fact]
		public async Task Can_Create_And_Delete_Ledger()
		{
			var ledgerName = nameof(this.Can_Create_And_Delete_Ledger);

			var createMutation = $@"mutation {{
									  ledgerMutation {{
									    createLedger(ledgerInput: {{name: ""{ledgerName}""}}) {{
									      id
									      name
									      created
									      lastUpdated
									    }}
									  }}
									}}";

			var testResult = await this.RunTest<Ledger>(
				createMutation,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["ledgerMutation"] !["createLedger"] !,
				(ledger) =>
				{
					ledger.Name.Should().Be(ledgerName);
					ledger.Id.Should().NotBeEmpty();
					ledger.Created.Should().BeBefore(DateTime.UtcNow);
					ledger.LastUpdated.Should().Be(default(DateTime));
				});

			var deleteMutation = $@"mutation {{
									  ledgerMutation {{
									    deleteLedger(ledgerId: ""{testResult.DeserializedResponse.Id}"")
									  }}
									}}";

			await this.RunTest<string>(
				deleteMutation,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["ledgerMutation"] !["deleteLedger"] !,
				(message) => message.Should().Be("deleted"));
		}

		[Fact]
		public async Task Can_Create_Get_And_Delete_Ledger_Entries()
		{
			var ledgerId = Guid.Parse("6a58e91a-ec0d-447b-b958-0e0210208176");
			var payeeId = Guid.Parse("17FC72D5-C08F-4452-8CF4-395D40C83837");
			var categoryId = Guid.Parse("5311D853-B5BA-4880-ADEF-9E8E1085A541");

			var createMutation = $@"mutation {{
									  ledgerMutation {{
									    createLedgerEntries(ledgerEntryInput: [
									      {{
									        ledgerId:""{ledgerId}"",
									        payeeId: ""{payeeId}"",
									        categoryId:""{categoryId}""
									        amount:101.33,
									        entryDate: ""2022-05-17"",
									        isIncome:true
									      }},
									      {{
									        ledgerId:""{ledgerId}"",
									        payeeId: ""{payeeId}"",
									        categoryId:""{categoryId}""
									        amount:63.43,
									        entryDate: ""2022-05-16"",
									        isIncome:true
									      }}
									    ])
									  }}
									}}";

			await this.RunTest<int>(
				createMutation,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["ledgerMutation"] !["createLedgerEntries"] !,
				(entriesCreated) =>
				{
					entriesCreated.Should().Be(2);
				});

			var query = $@"query {{
							  ledgerEntryQuery {{
							    ledgerEntries(ledgerId: ""{ledgerId}"") {{
							      id
							      amount
							      entryDate
							      isIncome
							      payeeId
							      categoryId
							      ledgerId
							    }}
							  }}
							}}";

			var getLedgerEntriesTestResult = await this.RunTest<IEnumerable<LedgerEntry>>(
				query,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["ledgerEntryQuery"] !["ledgerEntries"] !,
				(ledgerEntries) =>
				{
					var enumerable = ledgerEntries.ToList();

					var entry = enumerable.Single(e => e.Amount == 101.33M);
					entry.Id.Should().NotBeEmpty();
					entry.LedgerId.Should().Be(ledgerId);
					entry.PayeeId.Should().Be(payeeId);
					entry.CategoryId.Should().Be(categoryId);
					entry.EntryDate.Should().Be(DateTime.Parse("2022-05-17"));
					entry.IsIncome.Should().BeTrue();

					entry = enumerable.Single(e => e.Amount == 63.43M);
					entry.Id.Should().NotBeEmpty();
					entry.LedgerId.Should().Be(ledgerId);
					entry.PayeeId.Should().Be(payeeId);
					entry.CategoryId.Should().Be(categoryId);
					entry.EntryDate.Should().Be(DateTime.Parse("2022-05-16"));
					entry.IsIncome.Should().BeTrue();
				});

			var ledgerEntryIds = getLedgerEntriesTestResult.DeserializedResponse
				.Where(e => e.Amount is 101.33m or 63.43M)
				.Select(e => e.Id)
				.ToArray();

			var deleteMutation = $@"mutation {{
									  ledgerMutation {{
									    deleteLedgerEntries(ledgerEntryIds: [""{ledgerEntryIds[0]}"", ""{ledgerEntryIds[1]}""])
									  }}
									}}";

			await this.RunTest<int>(
				deleteMutation,
				(response) =>
				{
					response.StatusCode.Should().Be(HttpStatusCode.OK);
				},
				(jo) => jo["data"] !["ledgerMutation"] !["deleteLedgerEntries"] !,
				(entriesDeleted) =>
				{
					entriesDeleted.Should().Be(2);
				});
		}
	}
}
