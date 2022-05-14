// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Mutations;
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;

	public class LedgerSchema : Schema
	{
		public LedgerSchema(LedgerQuery ledgerQuery, LedgerMutation ledgerMutation)
		{
			this.Query = ledgerQuery;
			this.Mutation = ledgerMutation;
		}
		
	}
}
