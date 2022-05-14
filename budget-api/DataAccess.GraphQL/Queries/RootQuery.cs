﻿// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using global::GraphQL.Types;

	public class RootQuery : ObjectGraphType
	{
		public RootQuery()
		{
			this.Field<LedgerQuery>("ledgerQuery", resolve: _ => new { });
			this.Field<CategoryQuery>("categoryQuery", resolve: _ => new { });
		}
	}
}
