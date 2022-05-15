// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;

	public class CategoryMutation : ObjectGraphType
	{
		public CategoryMutation(ICategoryRepository repository)
		{
			this.FieldAsync<CategoryType>(
				"createCategory",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "categoryInput" }),
				resolve: async context => await repository.AddCategoryAsync(context.GetArgument<Category>("categoryInput") ?? throw new InvalidOperationException("Category is null.")));
		}
	}
}