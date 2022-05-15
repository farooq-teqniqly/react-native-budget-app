// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using global::GraphQL.Types;

	public class LedgerEntryInputType : InputObjectGraphType
	{
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