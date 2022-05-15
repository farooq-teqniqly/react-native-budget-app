// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;

	public class PayeeMutation : ObjectGraphType
	{
		public PayeeMutation(IPayeeRepository repository)
		{
			this.FieldAsync<CategoryType>(
				"createPayee",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PayeeInputType>> { Name = "payeeInput" }),
				resolve: async context => await repository.AddPayeeAsync(context.GetArgument<Payee>("payeeInput") ?? throw new InvalidOperationException("Payee is null.")));
		}
	}
}