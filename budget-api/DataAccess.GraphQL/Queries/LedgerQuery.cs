// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;

	public class LedgerQuery : ObjectGraphType
	{
		public LedgerQuery(ILedgerRepository repository)
		{
			this.FieldAsync<ListGraphType<LedgerType>>(
				"ledgers",
				resolve: async _ => await repository.GetLedgersAsync());

			this.FieldAsync<LedgerType>(
				"ledger",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "id" }),
				resolve: async context => await repository.GetLedgerAsync(context.GetArgument<Guid>("id")));
		}
	}
}
