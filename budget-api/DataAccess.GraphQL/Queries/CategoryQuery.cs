// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using global::GraphQL.Types;
	using Services;

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