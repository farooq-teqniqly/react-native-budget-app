namespace DataAccess.GraphQL.Schemas
{
	using global::GraphQL.Types;
	using Mutations;
	using Queries;

	public class CategorySchema : Schema
	{
		public CategorySchema(CategoryQuery ledgerQuery, CategoryMutation categoryMutation)
		{
			this.Query = ledgerQuery;
			this.Mutation = categoryMutation;
		}
	}
}