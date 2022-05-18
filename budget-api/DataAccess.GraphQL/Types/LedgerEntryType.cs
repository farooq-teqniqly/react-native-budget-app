// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Types
{
	using DataAccess.Entities;
	using global::GraphQL.Types;

	/// <summary>
	/// The LedgerEntry GraphQL type.
	/// </summary>
	public sealed class LedgerEntryType : ObjectGraphType<LedgerEntry>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerEntryType"/> class.
		/// </summary>
		public LedgerEntryType()
		{
			this.Field(e => e.Id);
			this.Field(e => e.EntryDate);
			this.Field(e => e.Amount);
			this.Field(e => e.IsIncome);
			this.Field(e => e.LedgerId);
			this.Field(e => e.PayeeId);
			this.Field(e => e.CategoryId);
			this.Field(e => e.Description);
		}
	}
}