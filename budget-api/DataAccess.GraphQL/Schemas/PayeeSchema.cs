namespace DataAccess.GraphQL.Schemas
{
	using global::GraphQL.Types;
	using Mutations;
	using Queries;

	public class PayeeSchema : Schema
	{
		public PayeeSchema(PayeeQuery payeeQuery, PayeeMutation payeeMutation)
		{
			this.Query = payeeQuery;
			this.Mutation = payeeMutation;
		}
	}
}