// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using global::GraphQL.Types;

	/// <summary>
	/// The Category input type.
	/// </summary>
	public class CategoryInputType : InputObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryInputType"/> class.
		/// </summary>
		public CategoryInputType()
		{
			this.Field<StringGraphType>("name");
		}
	}
}