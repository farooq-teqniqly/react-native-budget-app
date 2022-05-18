// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using global::GraphQL;
	using global::GraphQL.Types;

	/// <summary>
	/// The Payee mutation.
	/// </summary>
	public class PayeeMutation : ObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PayeeMutation"/> class.
		/// </summary>
		/// <param name="repository">The Payee repository.</param>
		public PayeeMutation(IPayeeRepository repository)
		{
			this.FieldAsync<PayeeType>(
				"createPayee",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PayeeInputType>> { Name = "payeeInput" }),
				resolve: async context => await repository.AddPayeeAsync(context.GetArgument<Payee>("payeeInput")
																		 ?? throw new InvalidOperationException("Payee is null.")));

			this.FieldAsync<StringGraphType>(
				name: "deletePayee",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "payeeId" }),
				resolve: async context =>
				{
					await repository.DeletePayeeAsync(context.GetArgument<Guid>("payeeId"));
					return "deleted";
				});
		}
	}
}