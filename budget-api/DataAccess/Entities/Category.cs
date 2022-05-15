// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace DataAccess.Entities
{
	/// <summary>
	/// Represents a ledger entry's category.
	/// </summary>
	public class Category : IEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Category"/> class.
		/// </summary>
		public Category()
		{
			this.LedgerEntries = new HashSet<LedgerEntry>();
		}

		/// <summary>
		/// Gets or sets the category id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the category name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the ledger entries associated with this category.
		/// </summary>
		public ICollection<LedgerEntry> LedgerEntries { get; set; }
	}
}
