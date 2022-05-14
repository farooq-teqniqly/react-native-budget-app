namespace DataAccess.GraphQL.Mutations
{
	using Entities;
	using global::GraphQL;
	using global::GraphQL.Types;
	using Services;
	using Types;

	public class CategoryMutation : ObjectGraphType
	{
		public CategoryMutation(IRepository repository)
		{
			this.FieldAsync<CategoryType>(
				"createCategory",
				arguments: new QueryArguments(new QueryArgument<CategoryInputType> { Name = "categoryInput" }),
				resolve: async context =>
				{
					var category = context.GetArgument<Category>("categoryInput");
					category = await repository.AddAsync(category);
					await repository.SaveChangesAsync();

					return category;
				});
		}
	}
}