// Copyright (c) Farooq Mahmud

namespace DataAccess.Repositories
{
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;

	public class PayeeRepository : IPayeeRepository
	{
		private readonly DatabaseContext databaseContext;

		public PayeeRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Payee>> GetPayeesAsync()
		{
			return await this.databaseContext.Payees.AsNoTracking().ToListAsync();
		}

		public async Task<Payee> AddPayeeAsync(Payee payee)
		{
			var newPayee = await this.databaseContext.Payees.AddAsync(payee);
			await this.databaseContext.SaveChangesAsync();
			return newPayee.Entity;
		}

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