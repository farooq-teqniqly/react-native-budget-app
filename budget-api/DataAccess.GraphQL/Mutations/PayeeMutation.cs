namespace DataAccess.GraphQL.Mutations
{
	using Entities;
	using global::GraphQL.Types;
	using Services;
	using Types;

	public class PayeeMutation : ObjectGraphType
	{
		public PayeeMutation(IRepository repository)
		{
			this.FieldAsync<CategoryType>(
				"createPayee",
				arguments: new QueryArguments(new QueryArgument<PayeeInputType> { Name = "payeeInput" }),
				resolve: async context =>
				{
					var payee = context.EnsureGetArgument<Payee>("payeeInput");
					payee = await repository.AddAsync(payee);
					await repository.SaveChangesAsync();

					return payee;
				});
		}
	}
}