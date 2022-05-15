// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using global::GraphQL.Types;

	public class RootMutation : ObjectGraphType
	{
		public RootMutation()
		{
			this.Field<LedgerMutation>("ledgerMutation", resolve: _ => new { });
			this.Field<CategoryMutation>("categoryMutation", resolve: _ => new { });
			this.Field<PayeeMutation>("payeeMutation", resolve: _ => new { });
		}
	}
}
