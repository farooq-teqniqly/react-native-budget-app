// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;

	public class LedgerEntryQuery : ObjectGraphType
	{
		public LedgerEntryQuery(ILedgerRepository repository)
		{
			this.FieldAsync<ListGraphType<LedgerEntryType>>(
				"ledgerEntries",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "ledgerId" }),
				resolve: async context => await repository.GetLedgerEntriesAsync(context.GetArgument<Guid>("ledgerId")));
		}
	}
}