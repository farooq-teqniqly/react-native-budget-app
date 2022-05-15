// Copyright (c) Farooq Mahmud

namespace DataAccess.Repositories
{
	using DataAccess.Entities;

	public interface IPayeeRepository
	{
		public Task<IEnumerable<Payee>> GetPayeesAsync();
		public Task<Payee> AddPayeeAsync(Payee payee);
		public Task<Payee?> DeletePayeeAsync(Guid id);
	}
}