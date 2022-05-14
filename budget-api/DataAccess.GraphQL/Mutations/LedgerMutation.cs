// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Mutations
{
	using DataAccess.Entities;
	using DataAccess.GraphQL.Types;
	using global::GraphQL;
	using global::GraphQL.Types;
	using Services;

	public class LedgerMutation : ObjectGraphType
	{
		public LedgerMutation(IRepository repository, IDateTimeService dateTimeService)
		{
			this.FieldAsync<LedgerType>(
				"createLedger",
				arguments: new QueryArguments(new QueryArgument<LedgerInputType> { Name = "ledgerInput" }),
				resolve: async context =>
				{
					var ledger = context.GetArgument<Ledger>("ledgerInput");

					if (ledger == null)
					{
						throw new ArgumentNullException(paramName: "ledgerInput");
					}

					ledger.Created = dateTimeService.DateTime;
					ledger = await repository.AddAsync(ledger);
					await repository.SaveChangesAsync();

					return ledger;
				});

			this.FieldAsync<StringGraphType>(
				"deleteLedger",
				arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
				resolve: async context =>
				{
					var ledger = await repository.GetAsync<Ledger>(context.GetArgument<Guid>("id"));

					if (ledger != null)
					{
						repository.Remove(ledger);
						await repository.SaveChangesAsync();
					}

					return "deleted";
				});
		}
	}
}
