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
		/// Gets or sets the category id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the category name.
		/// </summary>
		public string Name { get; set; }
	}
}
