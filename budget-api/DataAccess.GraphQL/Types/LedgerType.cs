// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using DataAccess.Entities;
	using global::GraphQL.Types;

	/// <summary>
	/// The Ledger GraphQL type.
	/// </summary>
	public sealed class LedgerType : ObjectGraphType<Ledger>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerType"/> class.
		/// </summary>
		public LedgerType()
		{
			this.Field(l => l.Id);
			this.Field(l => l.Name);
			this.Field(l => l.Created);
			this.Field(l => l.LastUpdated);
		}
	}
}
