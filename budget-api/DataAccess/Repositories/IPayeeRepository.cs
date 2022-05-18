// Copyright (c) Farooq Mahmud

namespace DataAccess.Repositories
{
	using DataAccess.Entities;

	/// <summary>
	/// A repository for Payee entities.
	/// </summary>
	public interface IPayeeRepository
	{
		/// <summary>
		/// Gets all payees.
		/// </summary>
		/// <returns>The list of payees.</returns>
		public Task<IEnumerable<Payee>> GetPayeesAsync();

		/// <summary>
		/// Adds a payee.
		/// </summary>
		/// <param name="payee">The payee.</param>
		/// <returns>The added payee.</returns>
		public Task<Payee> AddPayeeAsync(Payee payee);

		/// <summary>
		/// Deletes a payee.
		/// </summary>
		/// <param name="id">The payee id.</param>
		/// <returns>The deleted payee or null if the payee was not found.</returns>
		public Task<Payee?> DeletePayeeAsync(Guid id);
	}
}