// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using DataAccess.Entities;
	using global::GraphQL.Types;

	/// <summary>
	/// The Payee GraphQL type.
	/// </summary>
	public sealed class PayeeType : ObjectGraphType<Payee>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PayeeType"/> class.
		/// </summary>
		public PayeeType()
		{
			this.Field(p => p.Id);
			this.Field(p => p.Name);
		}
	}
}