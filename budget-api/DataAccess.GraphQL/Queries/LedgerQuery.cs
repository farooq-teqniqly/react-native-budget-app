// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using global::GraphQL;
	using global::GraphQL.Types;
	using Repositories;
	using Services;

	public class LedgerQuery : ObjectGraphType
	{
		public LedgerQuery(ILedgerRepository repository)
		{
			this.FieldAsync<ListGraphType<LedgerType>>(
				"ledgers",
				resolve: async _ => await repository.GetLedgersAsync());

			this.FieldAsync<LedgerType>(
				"ledger",
				arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
				resolve: async context =>
				{
					var ledgerId = context.EnsureGetArgument<Guid>("id");
					return await repository.GetLedgerAsync(ledgerId);
				});
		}
	}
}
