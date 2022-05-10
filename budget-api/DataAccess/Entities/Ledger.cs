// Copyright (c) Farooq Mahmud

namespace DataAccess.Entities
{
	/// <summary>
	/// Represents a ledger which is a collection of ledger entries.
	/// </summary>
	public class Ledger : IEntity
	{
		/// <summary>
		/// Gets or sets the ledger id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the date the ledger was created.
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// Gets or sets the date the ledger was last updated.
		/// </summary>
		public DateTime LastUpdated { get; set; }

		/// <summary>
		/// Gets or sets the entries associated with the ledger.
		/// </summary>
		public ICollection<LedgerEntry>? LedgerEntries { get; set; }

		/// <summary>
		/// Gets or sets the user who owns the ledger.
		/// </summary>
		public User? User { get; set; }
	}
}
