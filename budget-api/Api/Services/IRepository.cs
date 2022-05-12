// Copyright (c) Farooq Mahmud

namespace Api.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using DataAccess.Entities;

	/// <summary>
	/// A generic repository interface implementing the unit of work pattern.
	/// </summary>
	public interface IRepository
	{
		/// <summary>
		/// Adds the entity to the unit of work.
		/// </summary>
		/// <typeparam name="TEntity">The entity's type.</typeparam>
		/// <param name="entity">The entity.</param>
		/// <returns>The entity which was added.</returns>
		Task<TEntity> AddAsync<TEntity>(TEntity entity)
			where TEntity : class, IEntity;

		/// <summary>
		/// Removes the entity from the unit of work.
		/// </summary>
		/// <typeparam name="TEntity">The entity's type.</typeparam>
		/// <param name="entity">The entity.</param>
		/// <returns>The entity which was removed.</returns>
		TEntity Remove<TEntity>(TEntity entity)
			where TEntity : class, IEntity;

		/// <summary>
		/// Gets the entity with the specified id.
		/// </summary>
		/// <typeparam name="TEntity">The entity's type.</typeparam>
		/// <param name="id">The entity id.</param>
		/// <param name="readOnly">When true, changes to the entity are not tracked.</param>
		/// <returns>The found entity or null if the entity was not found.</returns>
		Task<TEntity?> GetAsync<TEntity>(Guid id, bool readOnly = true)
			where TEntity : class, IEntity;

		/// <summary>
		/// Gets all entities of the specified type.
		/// </summary>
		/// <typeparam name="TEntity">The entity's type.</typeparam>
		/// <param name="readOnly">When true, changes to the entity are not tracked.</param>
		/// <returns>A collection of all the entities of the specified type.</returns>
		Task<IEnumerable<TEntity>> GetAsync<TEntity>(bool readOnly = true)
			where TEntity : class, IEntity;

		/// <summary>
		/// Saves the changes in the unit of work to the database.
		/// </summary>
		/// <returns>The number of records saved.</returns>
		Task<int> SaveChangesAsync();
	}
}
