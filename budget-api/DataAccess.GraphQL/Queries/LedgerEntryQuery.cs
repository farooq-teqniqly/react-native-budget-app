namespace DataAccess.GraphQL.Queries
{
	using Entities;
	using global::GraphQL.Types;
	using Services;
	using Types;

	public class LedgerEntryQuery : ObjectGraphType
	{
		public LedgerEntryQuery(IRepository repository)
		{
			this.Field<ListGraphType<LedgerEntryType>>(
				"ledgerEntries",
				arguments: new QueryArguments(new QueryArgument<GuidGraphType> {Name = "ledgerId"}),
				resolve: context =>
				{
					var ledgerId = context.EnsureGetArgument<Guid>("ledgerId");
					return repository.Get<LedgerEntry>(le => le.LedgerId == ledgerId).ToList();
				});
		}
	}
}