// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using DataAccess.GraphQL.Mutations;
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;

	/// <summary>
	/// The Payee GraphQL schema.
	/// </summary>
	public class PayeeSchema : Schema
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PayeeSchema"/> class.
		/// </summary>
		/// <param name="payeeQuery">The Payee query.</param>
		/// <param name="payeeMutation">The Payee mutation.</param>
		public PayeeSchema(PayeeQuery payeeQuery, PayeeMutation payeeMutation)
		{
			this.Query = payeeQuery;
			this.Mutation = payeeMutation;
		}
	}
}