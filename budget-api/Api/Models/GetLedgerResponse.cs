// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	/// <summary>
	/// Encapsulates a get ledger API response.
	/// </summary>
	public class GetLedgerResponse
	{
		/// <summary>
		/// Gets or sets the ledger id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the ledger name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the ledger create date.
		/// </summary>
		public DateTime Created { get; set; }

		/// <summary>
		/// Gets or sets the date the ledger was last updated.
		/// </summary>
		public DateTime LastUpdated { get; set; }
	}
}