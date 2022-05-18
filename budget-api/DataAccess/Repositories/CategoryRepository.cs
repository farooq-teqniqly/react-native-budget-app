// Copyright (c) Farooq Mahmud

namespace DataAccess.Repositories
{
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// A repository for category entities.
	/// </summary>
	public class CategoryRepository : ICategoryRepository
	{
		private readonly DatabaseContext databaseContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryRepository"/> class.
		/// </summary>
		/// <param name="databaseContext">The EF Core database context.</param>
		public CategoryRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			return await this.databaseContext.Categories.AsNoTracking().ToListAsync();
		}

		/// <inheritdoc/>
		public async Task<Category> AddCategoryAsync(Category category)
		{
			var newCategory = (await this.databaseContext.Categories.AddAsync(category)).Entity;
			await this.databaseContext.SaveChangesAsync();
			return newCategory;
		}

		/// <inheritdoc/>
		public async Task<Category?> DeleteCategoryAsync(Guid id)
		{
			var category = this.databaseContext.Categories.FirstOrDefault(c => c.Id == id);

			if (category != null)
			{
				category = this.databaseContext.Categories.Remove(category).Entity;
				await this.databaseContext.SaveChangesAsync();
				return category;
			}

			return null;
		}
	}
}