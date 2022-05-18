// Copyright (c) Farooq Mahmud

namespace DataAccess.Repositories
{
	using DataAccess.Entities;

	/// <summary>
	/// A repository for Category entities.
	/// </summary>
	public interface ICategoryRepository
	{
		/// <summary>
		/// Gets all the categories.
		/// </summary>
		/// <returns>The list of categories.</returns>
		public Task<IEnumerable<Category>> GetCategoriesAsync();

		/// <summary>
		/// Adds a category.
		/// </summary>
		/// <param name="category">The category to add.</param>
		/// <returns>The added category.</returns>
		public Task<Category> AddCategoryAsync(Category category);

		/// <summary>
		/// Deletes a category.
		/// </summary>
		/// <param name="id">The category id.</param>
		/// <returns>The deleted category or null if the category was not found.</returns>
		public Task<Category?> DeleteCategoryAsync(Guid id);
	}
}