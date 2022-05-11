// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	/// <summary>
	/// Encapsulates the API response to ledger creation.
	/// </summary>
	public class CreateLedgerResponse
	{
		/// <summary>
		/// Gets or sets the ledger id.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the ledger create date.
		/// </summary>
		public DateTime Created { get; set; }
	}
}