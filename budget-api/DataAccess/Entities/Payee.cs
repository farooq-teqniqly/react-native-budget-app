﻿// Copyright (c) Farooq Mahmud

namespace DataAccess.Entities
{
	/// <summary>
	/// Represents a payee.
	/// </summary>
	public class Payee : IEntity
	{
		/// <summary>
		/// Gets or sets the payee id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the payee name.
		/// </summary>
		public string? Name { get; set; }
	}
}