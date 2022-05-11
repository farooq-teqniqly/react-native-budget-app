// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	/// <summary>
	/// Encapsulates a create payee API response.
	/// </summary>
	public class CreatePayeeResponse
	{
		/// <summary>
		/// Gets or sets the payee id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the payee name.
		/// </summary>
		public string Name { get; set; }
	}
}