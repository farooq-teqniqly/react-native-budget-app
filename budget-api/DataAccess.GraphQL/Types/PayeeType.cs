// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using DataAccess.Entities;
	using global::GraphQL.Types;

	public sealed class PayeeType : ObjectGraphType<Payee>
	{
		public PayeeType()
		{
			this.Field(p => p.Id);
			this.Field(p => p.Name);
		}
	}
}