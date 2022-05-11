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
	/// A controller for working with payees..
	/// </summary>
	[Route("api/payees")]
	[ApiController]
	public class PayeeController : ControllerBase
	{
		private readonly IRepository repository;
		private readonly IMapper mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="PayeeController"/> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="mapper">The entity mapper.</param>
		public PayeeController(IRepository repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		/// <summary>
		/// Gets all payees.
		/// </summary>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpGet]
		[Route("", Name = "GetPayees")]
		[ProducesResponseType(typeof(GetPayeeResponse[]), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetPayees()
		{
			var payees = (await this.repository.GetAsync<Payee>()).ToArray();
			var response = this.mapper.Map<Payee[], GetPayeeResponse[]>(payees);

			return this.Ok(response);
		}

		/// <summary>
		/// Creates a new payee.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(CreatePayeeResponse), (int)HttpStatusCode.Created)]
		public async Task<IActionResult> CreatePayee([FromBody] CreatePayeeRequest request)
		{
			var payee = this.mapper.Map<CreatePayeeRequest, Payee>(request);
			payee = await this.repository.AddAsync(payee);
			await this.repository.SaveChangesAsync();

			var response = this.mapper.Map<Payee, CreatePayeeResponse>(payee);

			return this.CreatedAtRoute("GetPayees", value: response);
		}

		/// <summary>
		/// Deletes the specified payee.
		/// </summary>
		/// <param name="payeeId">The payee id.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpDelete]
		[Route("{payeeId}")]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<IActionResult> DeletePayee(Guid payeeId)
		{
			var payee = await this.repository.GetAsync<Payee>(payeeId);

			if (payee != null)
			{
				this.repository.Remove(payee);
				await this.repository.SaveChangesAsync();
			}

			return this.NoContent();
		}
	}
}
