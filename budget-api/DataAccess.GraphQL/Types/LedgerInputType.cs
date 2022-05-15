// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using global::GraphQL.Types;

	public class LedgerInputType : InputObjectGraphType
	{
		public LedgerInputType()
		{
			this.Field<StringGraphType>("name");
		}
	}
}
