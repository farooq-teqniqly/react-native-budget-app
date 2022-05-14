namespace DataAccess.GraphQL.Types
{
	using global::GraphQL.Types;

	public class CategoryInputType : InputObjectGraphType
	{
		public CategoryInputType()
		{
			this.Field<StringGraphType>("name");
		}
	}
}