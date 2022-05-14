// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using global::GraphQL.Types;
	using Repositories;
	using Services;

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