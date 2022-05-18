// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using DataAccess.Entities;
	using global::GraphQL.Types;

	/// <summary>
	/// The Category GraphQL type.
	/// </summary>
	public sealed class CategoryType : ObjectGraphType<Category>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryType"/> class.
		/// </summary>
		public CategoryType()
		{
			this.Field(c => c.Id);
			this.Field(c => c.Name);
		}
	}
}