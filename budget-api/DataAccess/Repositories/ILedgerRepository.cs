// Copyright (c) Farooq Mahmud

namespace DataAccess.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using DataAccess.Entities;

	/// <summary>
	/// A repository for Ledger entities.
	/// </summary>
	public interface ILedgerRepository
	{
		/// <summary>
		/// Gets all ledgers.
		/// </summary>
		/// <returns>The list of ledgers.</returns>
		public Task<IEnumerable<Ledger>> GetLedgersAsync();

		/// <summary>
		/// Gets the specified ledger.
		/// </summary>
		/// <param name="id">The ledger id.</param>
		/// <returns>The ledger or null if the ledger was not found.</returns>
		public Task<Ledger?> GetLedgerAsync(Guid id);

		/// <summary>
		/// Gets the entries in the specified ledger.
		/// </summary>
		/// <param name="ledgerId">The ledger id.</param>
		/// <returns>The list of ledger entries in the ledger.</returns>
		public Task<IEnumerable<LedgerEntry>> GetLedgerEntriesAsync(Guid ledgerId);

		/// <summary>
		/// Adds a ledger.
		/// </summary>
		/// <param name="ledger">The ledger.</param>
		/// <returns>The added ledger.</returns>
		public Task<Ledger> AddLedgerAsync(Ledger ledger);

		/// <summary>
		/// Adds ledger entries to the specified ledger.
		/// </summary>
		/// <param name="ledgerEntries">The ledger entries.</param>
		/// <returns>The number of entries added to the ledger.</returns>
		public Task<int> AddLedgerEntriesAsync(IEnumerable<LedgerEntry> ledgerEntries);

		/// <summary>
		/// Deletes the ledger.
		/// </summary>
		/// <param name="id">The ledger id.</param>
		/// <returns>The deleted ledger or null if the ledger was not found.</returns>
		public Task<Ledger?> DeleteLedgerAsync(Guid id);

		/// <summary>
		/// Deletes the specified ledger entries.
		/// </summary>
		/// <param name="ledgerEntryIds">The ledger entry ids to delete.</param>
		/// <returns>The number of ledger entries deleted.</returns>
		public Task<int> DeleteLedgerEntriesAsync(IEnumerable<Guid> ledgerEntryIds);
	}
}
