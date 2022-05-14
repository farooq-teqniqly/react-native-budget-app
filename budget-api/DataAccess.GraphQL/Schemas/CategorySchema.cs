// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Mutations;
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;

	public class CategorySchema : Schema
	{
		public CategorySchema(CategoryQuery ledgerQuery, CategoryMutation categoryMutation)
		{
			this.Query = ledgerQuery;
			this.Mutation = categoryMutation;
		}
	}
}