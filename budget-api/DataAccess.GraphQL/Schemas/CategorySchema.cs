// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Mutations;
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;

	/// <summary>
	/// The Category schema.
	/// </summary>
	public class CategorySchema : Schema
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CategorySchema"/> class.
		/// </summary>
		/// <param name="categoryQuery">The query associated with this schema.</param>
		/// <param name="categoryMutation">The mutation associated with this schema.</param>
		public CategorySchema(CategoryQuery categoryQuery, CategoryMutation categoryMutation)
		{
			this.Query = categoryQuery;
			this.Mutation = categoryMutation;
		}
	}
}