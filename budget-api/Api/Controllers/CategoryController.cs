// Copyright (c) Farooq Mahmud

namespace Api.Controllers
{
	using System;
	using System.Net;
	using System.Threading.Tasks;
	using Api.Models;
	using Api.Services;
	using AutoMapper;
	using DataAccess.Entities;
	using Microsoft.AspNetCore.Mvc;

	/// <summary>
	/// A controller for working with categories.
	/// </summary>
	[Route("api/categories")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IRepository repository;
		private readonly IMapper mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryController"/> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="mapper">The entity mapper.</param>
		public CategoryController(IRepository repository, IMapper mapper)
		{
			this.repository = repository;
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
			var categories = (await this.repository.GetAsync<Category>()).ToArray();
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
			category = await this.repository.AddAsync(category);
			await this.repository.SaveChangesAsync();

			var response = this.mapper.Map<Category, CreateCategoryResponse>(category);

			return this.CreatedAtRoute("GetCategories", value: response);
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
			var category = await this.repository.GetAsync<Category>(categoryId);

			if (category != null)
			{
				this.repository.Remove(category);
				await this.repository.SaveChangesAsync();
			}

			return this.NoContent();
		}
	}
}
