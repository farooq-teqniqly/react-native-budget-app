// Copyright (c) Farooq Mahmud

namespace DataAccess.Repositories
{
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// A repository for Payee entities.
	/// </summary>
	public class PayeeRepository : IPayeeRepository
	{
		private readonly DatabaseContext databaseContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="PayeeRepository"/> class.
		/// </summary>
		/// <param name="databaseContext">The EF Core database context.</param>
		public PayeeRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<Payee>> GetPayeesAsync()
		{
			return await this.databaseContext.Payees.AsNoTracking().ToListAsync();
		}

		/// <inheritdoc/>
		public async Task<Payee> AddPayeeAsync(Payee payee)
		{
			var newPayee = await this.databaseContext.Payees.AddAsync(payee);
			await this.databaseContext.SaveChangesAsync();
			return newPayee.Entity;
		}

		/// <inheritdoc/>
		public async Task<Payee?> DeletePayeeAsync(Guid id)
		{
			var payee = await this.databaseContext.Payees.SingleOrDefaultAsync(p => p.Id == id);

			if (payee != null)
			{
				payee = this.databaseContext.Payees.Remove(payee).Entity;
				await this.databaseContext.SaveChangesAsync();
				return payee;
			}

			return null;
		}
	}
}