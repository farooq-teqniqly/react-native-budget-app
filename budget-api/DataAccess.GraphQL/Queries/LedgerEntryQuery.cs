// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;

	/// <summary>
	/// The LedgerEntry query.
	/// </summary>
	public class LedgerEntryQuery : ObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerEntryQuery"/> class.
		/// </summary>
		/// <param name="repository">The Ledger repository.</param>
		public LedgerEntryQuery(ILedgerRepository repository)
		{
			this.FieldAsync<ListGraphType<LedgerEntryType>>(
				"ledgerEntries",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "ledgerId" }),
				resolve: async context => await repository.GetLedgerEntriesAsync(context.GetArgument<Guid>("ledgerId")));
		}
	}
}