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
	/// A controller for working with payees..
	/// </summary>
	[Route("api/payees")]
	[ApiController]
	public class PayeeController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;
		private readonly IMapper mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="PayeeController"/> class.
		/// </summary>
		/// <param name="databaseContext">The database context.</param>
		/// <param name="mapper">The entity mapper.</param>
		public PayeeController(DatabaseContext databaseContext, IMapper mapper)
		{
			this.databaseContext = databaseContext;
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
			var payees = await this.databaseContext.Payees.ToArrayAsync();
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
			this.databaseContext.Payees.Add(payee);
			await this.databaseContext.SaveChangesAsync();

			var response = this.mapper.Map<Payee, CreatePayeeRequest>(payee);

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
			var payee = await this.databaseContext.Payees.FirstOrDefaultAsync(p => p.Id == payeeId);

			if (payee != null)
			{
				this.databaseContext.Payees.Remove(payee);
				await this.databaseContext.SaveChangesAsync();
			}

			return this.NoContent();
		}
	}
}
