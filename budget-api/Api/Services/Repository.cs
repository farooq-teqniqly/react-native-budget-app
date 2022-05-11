// Copyright (c) Farooq Mahmud

namespace Api.Services
{
	using DataAccess;
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// A generic repository implementing EF Core's unit of work.
	/// </summary>
	public class Repository : IRepository
	{
		private readonly DatabaseContext databaseContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="Repository"/> class.
		/// </summary>
		/// <param name="databaseContext">The EF Core database context.</param>
		public Repository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		/// <inheritdoc />
		public async Task<TEntity> AddAsync<TEntity>(TEntity entity)
			where TEntity : class, IEntity
		{
			return (await this.databaseContext.Set<TEntity>().AddAsync(entity)).Entity;
		}

		/// <inheritdoc />
		public TEntity Remove<TEntity>(TEntity entity)
			where TEntity : class, IEntity
		{
			return this.databaseContext.Set<TEntity>().Remove(entity).Entity;
		}

		/// <inheritdoc />
		public async Task<TEntity?> GetAsync<TEntity>(Guid id, bool readOnly = true)
			where TEntity : class, IEntity
		{
			var set = this.databaseContext.Set<TEntity>();

			if (readOnly)
			{
				return await set.AsNoTracking().SingleOrDefaultAsync();
			}

			return await set.FindAsync(id);
		}

		/// <inheritdoc />
		public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(bool readOnly = true)
			where TEntity : class, IEntity
		{
			var set = this.databaseContext.Set<TEntity>();

			if (readOnly)
			{
				return await set.AsNoTracking().ToListAsync();
			}

			return await set.ToListAsync();
		}

		/// <inheritdoc />
		public async Task<int> SaveChangesAsync()
		{
			return await this.databaseContext.SaveChangesAsync();
		}
	}
}