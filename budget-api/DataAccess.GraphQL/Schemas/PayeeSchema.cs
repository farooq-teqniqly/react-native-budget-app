// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Mutations;
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;

	public class PayeeSchema : Schema
	{
		public PayeeSchema(PayeeQuery payeeQuery, PayeeMutation payeeMutation)
		{
			this.Query = payeeQuery;
			this.Mutation = payeeMutation;
		}
	}
}