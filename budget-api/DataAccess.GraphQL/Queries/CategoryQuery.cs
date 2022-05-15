// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL.Types;

	public class CategoryQuery : ObjectGraphType
	{
		public CategoryQuery(ICategoryRepository repository)
		{
			this.FieldAsync<ListGraphType<CategoryType>>(
				"categories",
				resolve: async _ => await repository.GetCategoriesAsync());
		}
	}
}