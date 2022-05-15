// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;
	using Services;

	public class LedgerMutation : ObjectGraphType
	{
		public LedgerMutation(ILedgerRepository repository, IDateTimeService dateTimeService)
		{
			this.FieldAsync<LedgerType>(
				"createLedger",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LedgerInputType>> { Name = "ledgerInput" }),
				resolve: async context =>
				{
					var ledger = context.GetArgument<Ledger>("ledgerInput") ?? throw new InvalidOperationException("Ledger is null.");
					ledger.Created = dateTimeService.DateTime;
					ledger = await repository.AddLedgerAsync(ledger);
					return ledger;
				});

			this.FieldAsync<StringGraphType>(
				"deleteLedger",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id" }),
				resolve: async context =>
				{
					await repository.DeleteLedgerAsync(context.GetArgument<Guid>("id"));
					return "deleted";
				});

			this.FieldAsync<IntGraphType>(
				"createLedgerEntries",
				arguments: new QueryArguments(new QueryArgument<ListGraphType<NonNullGraphType<LedgerEntryInputType>>>
					{ Name = "ledgerEntryInput" }),
				resolve: async context => await repository.AddLedgerEntriesAsync(context.GetArgument<IEnumerable<LedgerEntry>>("ledgerEntryInput") ?? throw new InvalidOperationException("LedgerEntry is null.")));

			this.FieldAsync<IntGraphType>(
				"deleteLedgerEntries",
				arguments: new QueryArguments(new QueryArgument<ListGraphType<NonNullGraphType<GuidGraphType>>>
					{ Name = "ledgerEntryIds" }),
				resolve: async context => await repository.DeleteLedgerEntriesAsync(context.GetArgument<IEnumerable<Guid>>("ledgerEntryIds") ?? throw new InvalidOperationException("Id list is null.")));
		}
	}
}
