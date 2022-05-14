namespace DataAccess.GraphQL.Queries
{
	using Entities;
	using global::GraphQL.Types;
	using Repositories;
	using Services;
	using Types;

	public class LedgerEntryQuery : ObjectGraphType
	{
		public LedgerEntryQuery(ILedgerRepository repository)
		{
			this.FieldAsync<ListGraphType<LedgerEntryType>>(
				"ledgerEntries",
				arguments: new QueryArguments(new QueryArgument<GuidGraphType> {Name = "ledgerId"}),
				resolve: async context =>
				{
					var ledgerId = context.EnsureGetArgument<Guid>("ledgerId");
					return await repository.GetLedgerEntriesAsync(ledgerId);
				});
		}
	}
}