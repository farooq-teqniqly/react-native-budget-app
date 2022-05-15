// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;

	public class LedgerEntrySchema : Schema
	{
		public LedgerEntrySchema(LedgerEntryQuery ledgerEntryQuery)
		{
			this.Query = ledgerEntryQuery;
		}
	}
}