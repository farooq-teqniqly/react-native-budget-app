// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using DataAccess.Entities;
	using global::GraphQL.Types;

	public sealed class LedgerEntryType : ObjectGraphType<LedgerEntry>
	{
		public LedgerEntryType()
		{
			this.Field(e => e.Id);
			this.Field(e => e.EntryDate);
			this.Field(e => e.Amount);
			this.Field(e => e.IsIncome);
		}
	}
}