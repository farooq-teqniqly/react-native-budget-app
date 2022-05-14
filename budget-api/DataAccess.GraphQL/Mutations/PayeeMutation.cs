namespace DataAccess.GraphQL.Mutations
{
	using Entities;
	using global::GraphQL.Types;
	using Repositories;
	using Services;
	using Types;

	public class PayeeMutation : ObjectGraphType
	{
		public PayeeMutation(IPayeeRepository repository)
		{
			this.FieldAsync<CategoryType>(
				"createPayee",
				arguments: new QueryArguments(new QueryArgument<PayeeInputType> { Name = "payeeInput" }),
				resolve: async context =>
				{
					var payee = context.EnsureGetArgument<Payee>("payeeInput");
					payee = await repository.AddPayeeAsync(payee);
					return payee;
				});
		}
	}
}