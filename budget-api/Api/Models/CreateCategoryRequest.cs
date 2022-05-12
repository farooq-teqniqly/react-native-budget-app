// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	/// <summary>
	/// Encapsulates a create category API request.
	/// </summary>
	public class CreateCategoryRequest
	{
		/// <summary>
		/// Gets or sets the category name.
		/// </summary>
		public string Name { get; set; }
	}
}
