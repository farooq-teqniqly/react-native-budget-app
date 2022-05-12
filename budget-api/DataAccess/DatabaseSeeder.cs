// Copyright (c) Farooq Mahmud

namespace DataAccess
{
	using System;
	using System.Threading.Tasks;
	using DataAccess.Entities;

	/// <summary>
	/// This class seeds the Budget database.
	/// </summary>
	public class DatabaseSeeder
	{
		private readonly DatabaseContext databaseContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseSeeder"/> class.
		/// </summary>
		/// <param name="databaseContext">The database context.</param>
		public DatabaseSeeder(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		/// <summary>
		/// Seeds the database.
		/// </summary>
		/// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
		public async Task SeedDatabaseAsync()
		{
			await this.databaseContext.Database.EnsureCreatedAsync();
			await this.SeedCategories();
			await this.SeedPayees();
			await this.SeedLedger();
			await this.databaseContext.SaveChangesAsync();
		}

		private async Task SeedLedger()
		{
			var ledger = new
			{
				Id = Guid.Parse("6a58e91a-ec0d-447b-b958-0e0210208176"), Name = "Demo Ledger",
				Created = DateTime.Parse("5-10-2022"),
			};

			if (await this.databaseContext.Ledgers.FindAsync(ledger.Id) == null)
			{
				this.databaseContext.Ledgers.Add(new Ledger
				{
					Id = ledger.Id,
					Created = ledger.Created,
					Name = ledger.Name,
				});
			}
		}

		private async Task SeedPayees()
		{
			var payees = new[]
			{
				new { Id = Guid.Parse("8ae49976-52f5-45e9-b6f9-72d2e4daacbf"), Name = "Safeway" },
				new { Id = Guid.Parse("682ebc46-c7bb-4f1c-aef0-b6a00691279a"), Name = "Denny's" },
				new { Id = Guid.Parse("44186c12-c48c-40ba-850e-6b4cc153f86a"), Name = "ACME Widgets" },
			};

			foreach (var payee in payees)
			{
				if (await this.databaseContext.Payees.FindAsync(payee.Id) == null)
				{
					await this.databaseContext.Payees.AddAsync(new Payee { Id = payee.Id, Name = payee.Name });
				}
			}
		}

		private async Task SeedCategories()
		{
			var categories = new[]
			{
				new { Id = Guid.Parse("c89d1d44-8719-47f5-8ab5-5281d005de3c"), Name = "Groceries" },
				new { Id = Guid.Parse("5311d853-b5ba-4880-adef-9e8e1085a541"), Name = "Dining out" },
				new { Id = Guid.Parse("5311d853-b5ba-4880-adef-9e8e1085a541"), Name = "Net Salary" },
			};

			foreach (var category in categories)
			{
				if (await this.databaseContext.Categories.FindAsync(category.Id) == null)
				{
					await this.databaseContext.Categories.AddAsync(new Category { Id = category.Id, Name = category.Name });
				}
			}
		}
	}
}
