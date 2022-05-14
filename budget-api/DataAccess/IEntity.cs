// Copyright (c) Farooq Mahmud

namespace DataAccess
{
	/// <summary>
	/// The IEntity interface is implemented by all entities.
	/// </summary>
	public interface IEntity
	{
		/// <summary>
		/// Gets or sets the entity id.
		/// </summary>
		public Guid Id { get; set; }
	}
}
