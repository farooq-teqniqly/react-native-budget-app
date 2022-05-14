namespace DataAccess.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Entities;

	public interface ILedgerRepository
	{
		public Task<IEnumerable<Ledger>> GetLedgersAsync();

		public Task<Ledger?> GetLedgerAsync(Guid id);
		public Task<IEnumerable<LedgerEntry>> GetLedgerEntriesAsync(Guid ledgerId);

		public Task<Ledger> AddLedgerAsync(Ledger ledger);
		public Task<int> AddLedgerEntriesAsync(IEnumerable<LedgerEntry> ledgerEntries);

		public Task<Ledger?> DeleteLedgerAsync(Guid id);
	}
}
