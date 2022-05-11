// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
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
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the date the user was created.
		/// </summary>
		public DateTime Created { get; set; }
	}
}
