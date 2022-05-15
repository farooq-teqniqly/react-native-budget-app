// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using DataAccess.Entities;
	using global::GraphQL.Types;

	public sealed class CategoryType : ObjectGraphType<Category>
	{
		public CategoryType()
		{
			this.Field(c => c.Id);
			this.Field(c => c.Name);
		}
	}
}