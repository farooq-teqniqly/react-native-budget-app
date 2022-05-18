// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using global::GraphQL.Types;

	/// <summary>
	/// The GraphQL root mutation.
	/// </summary>
	public class RootMutation : ObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RootMutation"/> class.
		/// </summary>
		public RootMutation()
		{
			this.Field<LedgerMutation>("ledgerMutation", resolve: _ => new { });
			this.Field<CategoryMutation>("categoryMutation", resolve: _ => new { });
			this.Field<PayeeMutation>("payeeMutation", resolve: _ => new { });
		}
	}
}
