namespace DataAccess.GraphQL.Queries
{
	using Entities;
	using global::GraphQL.Types;
	using Repositories;
	using Services;
	using Types;

	public class PayeeQuery : ObjectGraphType
	{
		public PayeeQuery(IPayeeRepository repository)
		{
			this.FieldAsync<ListGraphType<PayeeType>>(
				"payees",
				resolve: async _ => await repository.GetPayeesAsync());
		}
	}
}