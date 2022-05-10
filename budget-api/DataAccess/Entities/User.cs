// Copyright (c) Farooq Mahmud

namespace DataAccess.Entities
{
	/// <summary>
	/// Represents a user.
	/// </summary>
	public class User : IEntity
	{
		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the user name.
		/// </summary>
		public string? Name { get; set; }

		/// <summary>
		/// Gets or sets the date the user was created.
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// Gets or sets the ledger owned by the user.
		/// </summary>
		public Ledger? Ledger { get; set; }
	}
}
