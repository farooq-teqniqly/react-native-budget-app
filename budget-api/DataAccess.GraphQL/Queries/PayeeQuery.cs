// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Queries
{
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL.Types;

	/// <summary>
	/// The Payee GraphQL query.
	/// </summary>
	public class PayeeQuery : ObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PayeeQuery"/> class.
		/// </summary>
		/// <param name="repository">The Payee repository.</param>
		public PayeeQuery(IPayeeRepository repository)
		{
			this.FieldAsync<ListGraphType<PayeeType>>(
				"payees",
				resolve: async _ => await repository.GetPayeesAsync());
		}
	}
}