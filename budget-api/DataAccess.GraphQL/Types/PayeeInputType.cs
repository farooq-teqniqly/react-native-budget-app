namespace DataAccess.GraphQL.Types
{
	using global::GraphQL.Types;

	public class PayeeInputType : InputObjectGraphType
	{
		public PayeeInputType()
		{
			this.Field<StringGraphType>("name");
		}
	}
}