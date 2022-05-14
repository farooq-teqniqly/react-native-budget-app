namespace DataAccess.Repositories
{
	using Entities;
	using Microsoft.EntityFrameworkCore;

	public class CategoryRepository : ICategoryRepository
	{
		private readonly DatabaseContext databaseContext;

		public CategoryRepository(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			return await this.databaseContext.Categories.AsNoTracking().ToListAsync();
		}

		public async Task<Category> AddCategoryAsync(Category category)
		{
			var newCategory = (await this.databaseContext.Categories.AddAsync(category)).Entity;
			await this.databaseContext.SaveChangesAsync();
			return newCategory;
		}

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