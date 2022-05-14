// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;
	using DataAccess.GraphQL.Mutations;

	public class LedgerSchema : Schema
	{
		public LedgerSchema(LedgerQuery ledgerQuery, LedgerMutation ledgerMutation)
		{
			this.Query = ledgerQuery;
			this.Mutation = ledgerMutation;
		}
	}
}
