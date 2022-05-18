// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;

	/// <summary>
	/// The Category mutation.
	/// </summary>
	public class CategoryMutation : ObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryMutation"/> class.
		/// </summary>
		/// <param name="repository">The Category repository.</param>
		public CategoryMutation(ICategoryRepository repository)
		{
			this.FieldAsync<CategoryType>(
				"createCategory",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "categoryInput" }),
				resolve: async context => await repository.AddCategoryAsync(context.GetArgument<Category>("categoryInput")
																			?? throw new InvalidOperationException("Category is null.")));

			this.FieldAsync<StringGraphType>(
				name: "deleteCategory",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "categoryId" }),
				resolve: async context =>
				{
					await repository.DeleteCategoryAsync(context.GetArgument<Guid>("categoryId"));
					return "deleted";
				});
		}
	}
}