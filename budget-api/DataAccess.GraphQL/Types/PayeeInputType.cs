// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using global::GraphQL.Types;

	/// <summary>
	/// The Payee input type.
	/// </summary>
	public class PayeeInputType : InputObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PayeeInputType"/> class.
		/// </summary>
		public PayeeInputType()
		{
			this.Field<StringGraphType>("name");
		}
	}
}