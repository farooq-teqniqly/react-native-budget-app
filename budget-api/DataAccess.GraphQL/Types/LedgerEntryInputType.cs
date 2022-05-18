// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using global::GraphQL.Types;

	/// <summary>
	/// The LedgerEntryInput type.
	/// </summary>
	public class LedgerEntryInputType : InputObjectGraphType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerEntryInputType"/> class.
		/// </summary>
		public LedgerEntryInputType()
		{
			this.Field<DateGraphType>("entryDate");
			this.Field<FloatGraphType>("amount");
			this.Field<BooleanGraphType>("isIncome");
			this.Field<GuidGraphType>("ledgerId");
			this.Field<GuidGraphType>("payeeId");
			this.Field<GuidGraphType>("categoryId");
		}
	}
}