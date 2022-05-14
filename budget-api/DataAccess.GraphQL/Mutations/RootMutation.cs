namespace DataAccess.GraphQL.Mutations
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using global::GraphQL.Types;

	public class RootMutation : ObjectGraphType
	{
		public RootMutation()
		{
			this.Field<LedgerMutation>("ledgerMutation", resolve: context => new { });
			this.Field<CategoryMutation>("categoryMutation", resolve: context => new { });
			this.Field<PayeeMutation>("payeeMutation", resolve: context => new { });
		}
	}
}
