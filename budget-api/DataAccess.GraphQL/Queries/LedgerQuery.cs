// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using global::GraphQL;
	using global::GraphQL.Types;
	using Services;

	public class LedgerQuery : ObjectGraphType
	{
		public LedgerQuery(IRepository repository)
		{
			this.FieldAsync<ListGraphType<LedgerType>>(
				"ledgers",
				resolve: async _ => await repository.GetAsync<Ledger>());

			this.FieldAsync<LedgerType>(
				"ledger",
				arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
				resolve: async context => await repository.GetAsync<Ledger>(context.GetArgument<Guid>("id")));
		}
	}
}
