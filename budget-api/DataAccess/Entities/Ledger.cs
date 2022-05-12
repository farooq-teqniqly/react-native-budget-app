// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace DataAccess.Entities
{
	/// <summary>
	/// Represents a ledger which is a collection of ledger entries.
	/// </summary>
	public class Ledger : IEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Ledger"/> class.
		/// </summary>
		public Ledger()
		{
			this.LedgerEntries = new HashSet<LedgerEntry>();
		}

		/// <summary>
		/// Gets or sets the ledger id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the ledger name.
		/// </summary>
		public string Name { get; set; }

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
		public ICollection<LedgerEntry> LedgerEntries { get; set; }
	}
}
