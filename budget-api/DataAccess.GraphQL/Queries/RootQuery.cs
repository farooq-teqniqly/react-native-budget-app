// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using global::GraphQL.Types;

	/// <summary>
	/// The GraphQL root query.
	/// </summary>
	public class RootQuery : ObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RootQuery"/> class.
		/// </summary>
		public RootQuery()
		{
			this.Field<LedgerQuery>("ledgerQuery", resolve: _ => new { });
			this.Field<LedgerEntryQuery>("ledgerEntryQuery", resolve: _ => new { });
			this.Field<CategoryQuery>("categoryQuery", resolve: _ => new { });
			this.Field<PayeeQuery>("payeeQuery", resolve: _ => new { });
		}
	}
}
