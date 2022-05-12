// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	/// <summary>
	/// Encapsulates a get payee API response.
	/// </summary>
	public class GetPayeeResponse
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