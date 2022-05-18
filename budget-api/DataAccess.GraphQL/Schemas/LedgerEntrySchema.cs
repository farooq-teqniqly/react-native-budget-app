// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;

	/// <summary>
	/// LedgerEntry GraphQL schema.
	/// </summary>
	public class LedgerEntrySchema : Schema
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerEntrySchema"/> class.
		/// </summary>
		/// <param name="ledgerEntryQuery">The LedgerEntryQuery associated with this schema.</param>
		public LedgerEntrySchema(LedgerEntryQuery ledgerEntryQuery)
		{
			this.Query = ledgerEntryQuery;
		}
	}
}