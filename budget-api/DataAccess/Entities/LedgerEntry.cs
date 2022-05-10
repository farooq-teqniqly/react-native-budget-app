// Copyright (c) Farooq Mahmud

namespace DataAccess.Entities
{
	/// <summary>
	/// Represents a ledger entry.
	/// </summary>
	public class LedgerEntry : IEntity
	{
		/// <summary>
		/// Gets or sets the ledger entry id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the date of the ledger entry.
		/// </summary>
		public DateTime EntryDate { get; set; }

		/// <summary>
		/// Gets or sets the ledger entry amount.
		/// </summary>
		public decimal Amount { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the ledger entry corresponds to an income entry.
		/// </summary>
		public bool IsIncome { get; set; }

		/// <summary>
		/// Gets or sets the payee.
		/// </summary>
		public Payee? Payee { get; set; }

		/// <summary>
		/// Gets or sets the category.
		/// </summary>
		public Category? Category { get; set; }

		/// <summary>
		/// Gets or sets the ledger this entry belongs to.
		/// </summary>
		public Ledger? Ledger { get; set; }
	}
}
