// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	/// <summary>
	/// Encapsulates the get category API response.
	/// </summary>
	public class GetCategoryResponse
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
