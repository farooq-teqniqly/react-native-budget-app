// Copyright (c) Farooq Mahmud

namespace Api.Controllers
{
	using System;
	using System.Net;
	using System.Threading.Tasks;
	using Api.Models;
	using AutoMapper;
	using DataAccess;
	using DataAccess.Entities;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// A controller for working with categories.
	/// </summary>
	[Route("api/categories")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;
		private readonly IMapper mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryController"/> class.
		/// </summary>
		/// <param name="databaseContext">The database context.</param>
		/// <param name="mapper">The entity mapper.</param>
		public CategoryController(DatabaseContext databaseContext, IMapper mapper)
		{
			this.databaseContext = databaseContext;
			this.mapper = mapper;
		}

		/// <summary>
		/// Gets all categories.
		/// </summary>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpGet]
		[Route("", Name = "GetCategories")]
		[ProducesResponseType(typeof(GetCategoryResponse[]), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetCategories()
		{
			var categories = await this.databaseContext.Categories.ToArrayAsync();
			var response = this.mapper.Map<Category[], GetCategoryResponse[]>(categories);

			return this.Ok(response);
		}

		/// <summary>
		/// Creates a new category.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(CreateCategoryResponse), (int)HttpStatusCode.Created)]
		public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
		{
			var category = this.mapper.Map<CreateCategoryRequest, Category>(request);
			this.databaseContext.Categories.Add(category);
			await this.databaseContext.SaveChangesAsync();

			var response = this.mapper.Map<Category, CreateCategoryRequest>(category);

			return this.CreatedAtRoute("GetCategories", value: category);
		}

		/// <summary>
		/// Deletes the specified category.
		/// </summary>
		/// <param name="categoryId">The category id.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpDelete]
		[Route("{categoryId}")]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<IActionResult> DeleteCategory(Guid categoryId)
		{
			var category = await this.databaseContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

			if (category != null)
			{
				this.databaseContext.Categories.Remove(category);
				await this.databaseContext.SaveChangesAsync();
			}

			return this.NoContent();
		}
	}
}
