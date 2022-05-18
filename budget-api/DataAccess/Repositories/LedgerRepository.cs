// Copyright (c) Farooq Mahmud

namespace DataAccess.Repositories
{
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// A repository for ledger entities.
	/// </summary>
	public class LedgerRepository : ILedgerRepository
	{
		private readonly DatabaseContext databaseContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerRepository"/> class.
		/// </summary>
		/// <param name="databaseContext">The EF Core database context.</param>
		public LedgerRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<Ledger>> GetLedgersAsync()
		{
			return await this.databaseContext.Ledgers.AsNoTracking().ToListAsync();
		}

		/// <inheritdoc/>
		public Task<Ledger?> GetLedgerAsync(Guid id)
		{
			return this.databaseContext.Ledgers.AsNoTracking().SingleOrDefaultAsync(l => l.Id == id);
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<LedgerEntry>> GetLedgerEntriesAsync(Guid ledgerId)
		{
			return await this.databaseContext.LedgerEntries.AsNoTracking().Where(le => le.LedgerId == ledgerId).ToListAsync();
		}

		/// <inheritdoc/>
		public async Task<Ledger> AddLedgerAsync(Ledger ledger)
		{
			var newLedger = await this.databaseContext.Ledgers.AddAsync(ledger);
			await this.databaseContext.SaveChangesAsync();
			return newLedger.Entity;
		}

		/// <inheritdoc/>
		public async Task<int> AddLedgerEntriesAsync(IEnumerable<LedgerEntry> ledgerEntries)
		{
			await this.databaseContext.LedgerEntries.AddRangeAsync(ledgerEntries);
			return await this.databaseContext.SaveChangesAsync();
		}

		/// <inheritdoc/>
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

		/// <inheritdoc/>
		public async Task<int> DeleteLedgerEntriesAsync(IEnumerable<Guid> ledgerEntryIds)
		{
			foreach (var ledgerEntryId in ledgerEntryIds)
			{
				var ledgerEntry = await this.databaseContext.LedgerEntries.SingleOrDefaultAsync(e => e.Id == ledgerEntryId);

				if (ledgerEntry != null)
				{
					this.databaseContext.LedgerEntries.Remove(ledgerEntry);
				}
			}

			return await this.databaseContext.SaveChangesAsync();
		}
	}
}