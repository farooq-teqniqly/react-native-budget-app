namespace DataAccess.GraphQL.Queries
{
	using Entities;
	using global::GraphQL.Types;
	using Services;
	using Types;

	public class PayeeQuery : ObjectGraphType
	{
		public PayeeQuery(IRepository repository)
		{
			this.FieldAsync<ListGraphType<PayeeType>>(
				"payees",
				resolve: async _ => await repository.GetAsync<Payee>());
		}
	}
}