namespace DataAccess.GraphQL.Queries
{
	using Entities;
	using global::GraphQL.Types;
	using Services;
	using Types;

	public class CategoryQuery : ObjectGraphType
	{
		public CategoryQuery(IRepository repository)
		{
			this.FieldAsync<ListGraphType<CategoryType>>(
				"categories",
				resolve: async _ => await repository.GetAsync<Category>());
		}
	}
}