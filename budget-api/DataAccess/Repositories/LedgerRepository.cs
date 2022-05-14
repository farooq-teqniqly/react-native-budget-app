namespace DataAccess.Repositories
{
	using Entities;
	using Microsoft.EntityFrameworkCore;

	public class LedgerRepository : ILedgerRepository
	{
		private readonly DatabaseContext databaseContext;

		public LedgerRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Ledger>> GetLedgersAsync()
		{
			return await this.databaseContext.Ledgers.AsNoTracking().ToListAsync();
		}

		public Task<Ledger?> GetLedgerAsync(Guid id)
		{
			return this.databaseContext.Ledgers.AsNoTracking().SingleOrDefaultAsync(l => l.Id == id);
		}

		public async Task<IEnumerable<LedgerEntry>> GetLedgerEntriesAsync(Guid ledgerId)
		{
			return await this.databaseContext.LedgerEntries.AsNoTracking().Where(le => le.LedgerId == ledgerId).ToListAsync();
		}

		public async Task<Ledger> AddLedgerAsync(Ledger ledger)
		{
			var newLedger = await this.databaseContext.Ledgers.AddAsync(ledger);
			await this.databaseContext.SaveChangesAsync();
			return newLedger.Entity;
		}

		public async Task<int> AddLedgerEntriesAsync(IEnumerable<LedgerEntry> ledgerEntries)
		{
			await this.databaseContext.LedgerEntries.AddRangeAsync(ledgerEntries);
			return await this.databaseContext.SaveChangesAsync();
		}

		public async Task<Ledger?> DeleteLedgerAsync(Guid id)
		{
			var ledger = await this.databaseContext.Ledgers.SingleOrDefaultAsync(l => l.Id == id);

			if (ledger != null)
			{
				ledger = this.databaseContext.Ledgers.Remove(ledger).Entity;
				await this.databaseContext.SaveChangesAsync();
				return ledger;
			}

			return null;
		}
	}
}