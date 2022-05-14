namespace DataAccess.GraphQL.Schemas
{
	using global::GraphQL.Types;
	using Queries;

	public class LedgerEntrySchema : Schema
	{
		public LedgerEntrySchema(LedgerEntryQuery ledgerEntryQuery)
		{
			this.Query = ledgerEntryQuery;
		}

	}
}