// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace Api.Models
{
	/// <summary>
	/// Encapsulates an API request to create a ledger.
	/// </summary>
	public class CreateLedgerRequest
	{
		/// <summary>
		/// Gets or sets the ledger name.
		/// </summary>
		public string Name { get; set; }
	}
}