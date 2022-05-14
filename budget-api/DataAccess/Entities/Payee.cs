// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace DataAccess.Entities
{
	using Services;

	/// <summary>
	/// Represents a payee.
	/// </summary>
	public class Payee : IEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Payee"/> class.
		/// </summary>
		public Payee()
		{
			this.LedgerEntries = new HashSet<LedgerEntry>();
		}

		/// <summary>
		/// Gets or sets the payee id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the payee name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the ledger entries associated with this payee.
		/// </summary>
		public ICollection<LedgerEntry> LedgerEntries { get; set; }
	}
}
