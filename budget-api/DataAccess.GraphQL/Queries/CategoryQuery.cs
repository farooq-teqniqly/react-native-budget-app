// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL.Types;

	/// <summary>
	/// The Category query.
	/// </summary>
	public class CategoryQuery : ObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryQuery"/> class.
		/// </summary>
		/// <param name="repository">The Category repository.</param>
		public CategoryQuery(ICategoryRepository repository)
		{
			this.FieldAsync<ListGraphType<CategoryType>>(
				"categories",
				resolve: async _ => await repository.GetCategoriesAsync());
		}
	}
}