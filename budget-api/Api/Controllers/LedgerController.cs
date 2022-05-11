// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618

namespace Api.Controllers
{
	using System.Net;
	using Api.Models;
	using Api.Services;
	using AutoMapper;
	using DataAccess;
	using DataAccess.Entities;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// A controller for working with ledgers.
	/// </summary>
	[Route("api/ledgers")]
	[ApiController]
	public class LedgerController : ControllerBase
	{
		private readonly IRepository repository;
		private readonly IMapper mapper;
		private readonly IDateTimeService dateTimeService;

		/// <summary>
		/// Initializes a new instance of the <see cref="LedgerController"/> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="mapper">The entity mapper.</param>
		/// <param name="dateTimeService">The date time service.</param>
		public LedgerController(IRepository repository, IMapper mapper, IDateTimeService dateTimeService)
		{
			this.repository = repository;
			this.mapper = mapper;
			this.dateTimeService = dateTimeService;
		}

		/// <summary>
		/// Gets all the ledger ids.
		/// </summary>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpGet]
		[ProducesResponseType(typeof(Guid[]), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetLedgers()
		{
			var ledgerIds = (await this.repository.GetAsync<Ledger>()).Select(ledger => ledger.Id).ToArray();
			return this.Ok(ledgerIds);
		}

		/// <summary>
		/// Creates a new ledger.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(CreateLedgerResponse), (int)HttpStatusCode.Created)]
		public async Task<IActionResult> CreateLedger([FromBody] CreateLedgerRequest request)
		{
			var ledger = this.mapper.Map<CreateLedgerRequest, Ledger>(request);

			ledger.Created = this.dateTimeService.DateTime;
			ledger = await this.repository.AddAsync(ledger);
			await this.repository.SaveChangesAsync();

			var response = this.mapper.Map<Ledger, CreateLedgerResponse>(ledger);

			return this.CreatedAtRoute("GetLedger", new { ledgerId = response.Id }, response);
		}

		/// <summary>
		/// Gets the specified ledger along with its entries.
		/// </summary>
		/// <param name="ledgerId">The ledger id.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpGet]
		[Route("{ledgerId}", Name = "GetLedger")]
		[ProducesResponseType(typeof(GetLedgerResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetLedger(Guid ledgerId)
		{
			var ledger = await this.repository.GetAsync<Ledger>(ledgerId);

			if (ledger == null)
			{
				return this.NotFound();
			}

			var response = this.mapper.Map<Ledger, GetLedgerResponse>(ledger);
			return this.Ok(response);
		}

		/// <summary>
		/// Deletes the specified ledger.
		/// </summary>
		/// <param name="ledgerId">The ledger id.</param>
		/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
		[HttpDelete]
		[Route("{ledgerId}")]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<IActionResult> DeleteLedger(Guid ledgerId)
		{
			var ledger = await this.repository.GetAsync<Ledger>(ledgerId);

			if (ledger != null)
			{
				this.repository.Remove(ledger);
				await this.repository.SaveChangesAsync();
			}

			return this.NoContent();
		}
	}
}
