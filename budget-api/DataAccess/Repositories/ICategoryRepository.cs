namespace DataAccess.Repositories
{
	using Entities;

	public interface ICategoryRepository
	{
		public Task<IEnumerable<Category>> GetCategoriesAsync();
		public Task<Category> AddCategoryAsync(Category category);
		public Task<Category?> DeleteCategoryAsync(Guid id);
	}
}