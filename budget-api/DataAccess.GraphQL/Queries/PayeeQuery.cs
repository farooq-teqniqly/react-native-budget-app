// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL.Types;

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