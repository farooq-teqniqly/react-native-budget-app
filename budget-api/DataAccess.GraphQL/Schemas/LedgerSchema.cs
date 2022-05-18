// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Mutations;
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;

	/// <summary>
	/// The Ledger schema.
	/// </summary>
	public class LedgerSchema : Schema
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerSchema"/> class.
		/// </summary>
		/// <param name="ledgerQuery">The Ledger query.</param>
		/// <param name="ledgerMutation">The Ledger mutation.</param>
		public LedgerSchema(LedgerQuery ledgerQuery, LedgerMutation ledgerMutation)
		{
			this.Query = ledgerQuery;
			this.Mutation = ledgerMutation;
		}
	}
}
