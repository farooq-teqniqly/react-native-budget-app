// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using global::GraphQL;
	using global::GraphQL.Types;
	using Repositories;
	using Services;

	public class LedgerMutation : ObjectGraphType
	{
		public LedgerMutation(ILedgerRepository repository, IDateTimeService dateTimeService)
		{
			this.FieldAsync<LedgerType>(
				"createLedger",
				arguments: new QueryArguments(new QueryArgument<LedgerInputType> { Name = "ledgerInput" }),
				resolve: async context =>
				{
					var ledger = context.EnsureGetArgument<Ledger>("ledgerInput");
					ledger.Created = dateTimeService.DateTime;
					ledger = await repository.AddLedgerAsync(ledger);
					return ledger;
				});

			this.FieldAsync<StringGraphType>(
				"deleteLedger",
				arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
				resolve: async context =>
				{
					var ledgerId = context.EnsureGetArgument<Guid>("id");
					await repository.DeleteLedgerAsync(ledgerId);
					return "deleted";
				});

			this.FieldAsync<IntGraphType> (
				"createLedgerEntries",
				arguments: new QueryArguments(new QueryArgument<ListGraphType<LedgerEntryInputType>>
					{Name = "ledgerEntryInput"}),
				resolve: async context =>
				{
					var ledgerEntries = context.EnsureGetArgument<IEnumerable<LedgerEntry>>("ledgerEntryInput");
					return await repository.AddLedgerEntriesAsync(ledgerEntries);
				});
		}
	}
}
