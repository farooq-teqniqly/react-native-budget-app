// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	using System;

	/// <summary>
	/// Encapsulates the API response for creating a category.
	/// </summary>
	public class CreateCategoryResponse
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
