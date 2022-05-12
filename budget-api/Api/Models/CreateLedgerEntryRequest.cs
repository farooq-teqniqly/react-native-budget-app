// Copyright (c) Farooq Mahmud

namespace Api.Models
{
	/// <summary>
	/// Encapsulates a create ledger entry API request.
	/// </summary>
	public class CreateLedgerEntryRequest
	{
		/// <summary>
		/// Gets or sets the ledger entry date.
		/// </summary>
		public DateTime EntryDate { get; set; }

		/// <summary>
		/// Gets or sets the ledger amount.
		/// </summary>
		public decimal Amount { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the ledger entry is an income entry.
		/// </summary>
		public bool IsIncome { get; set; }

		/// <summary>
		/// Gets or sets the payee id.
		/// </summary>
		public Guid PayeeId { get; set; }

		/// <summary>
		/// Gets or sets the category id.
		/// </summary>
		public Guid CategoryId { get; set; }
	}
}