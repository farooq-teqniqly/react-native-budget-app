// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;

	/// <summary>
	/// The Ledger GraphQL query.
	/// </summary>
	public class LedgerQuery : ObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerQuery"/> class.
		/// </summary>
		/// <param name="repository">The Ledger repository.</param>
		public LedgerQuery(ILedgerRepository repository)
		{
			this.FieldAsync<ListGraphType<LedgerType>>(
				"ledgers",
				resolve: async _ => await repository.GetLedgersAsync());

			this.FieldAsync<LedgerType>(
				"ledger",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "ledgerId" }),
				resolve: async context => await repository.GetLedgerAsync(context.GetArgument<Guid>("ledgerId")));
		}
	}
}
