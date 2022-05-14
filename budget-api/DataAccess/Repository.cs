// Copyright (c) Farooq Mahmud

namespace DataAccess
{
	using Microsoft.EntityFrameworkCore;
	using Services;

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
				return await set.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
			}

			var x = await set.FindAsync(id);

			return x;
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

		public IEnumerable<TEntity> Get<TEntity>(Func<TEntity, bool> filter, bool readOnly = true) 
			where TEntity : class, IEntity
		{
			if (readOnly)
			{
				return this.databaseContext.Set<TEntity>().AsNoTracking().AsEnumerable().Where(filter);
			}

			return this.databaseContext.Set<TEntity>().AsEnumerable().Where(filter);
		}

		/// <inheritdoc />
		public async Task<int> SaveChangesAsync()
		{
			return await this.databaseContext.SaveChangesAsync();
		}
	}
}