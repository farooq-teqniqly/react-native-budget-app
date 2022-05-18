// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using global::GraphQL.Types;

	/// <summary>
	/// The Ledger input type.
	/// </summary>
	public class LedgerInputType : InputObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerInputType"/> class.
		/// </summary>
		public LedgerInputType()
		{
			this.Field<StringGraphType>("name");
		}
	}
}
