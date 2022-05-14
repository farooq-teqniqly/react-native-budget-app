// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using DataAccess.Entities;
	using global::GraphQL.Types;

	public sealed class LedgerType : ObjectGraphType<Ledger>
	{
		public LedgerType()
		{
			this.Field(l => l.Id);
			this.Field(l => l.Name);
			this.Field(l => l.Created);
			this.Field(l => l.LastUpdated);
		}
	}
}
