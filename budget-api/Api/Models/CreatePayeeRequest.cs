// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	/// <summary>
	/// Encapsulates a create payee API request.
	/// </summary>
	public class CreatePayeeRequest
	{
		/// <summary>
		/// Gets or sets the payee name.
		/// </summary>
		public string Name { get; set; }
	}
}