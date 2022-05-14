// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace DataAccess.Entities
{
	using Services;

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
		public Guid PayeeId { get; set; }

		/// <summary>
		/// Gets or sets the category.
		/// </summary>
		public Guid CategoryId { get; set; }

		/// <summary>
		/// Gets or sets the ledger id.
		/// </summary>
		public Guid LedgerId { get; set; }
	}
}
