// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using global::GraphQL;
	using global::GraphQL.Types;
	using Services;

	public class CategoryMutation : ObjectGraphType
	{
		public CategoryMutation(IRepository repository)
		{
			this.FieldAsync<CategoryType>(
				"createCategory",
				arguments: new QueryArguments(new QueryArgument<CategoryInputType> { Name = "categoryInput" }),
				resolve: async context =>
				{
					var category = context.EnsureGetArgument<Category>("categoryInput");
					category = await repository.AddAsync(category);
					await repository.SaveChangesAsync();

					return category;
				});
		}
	}
}