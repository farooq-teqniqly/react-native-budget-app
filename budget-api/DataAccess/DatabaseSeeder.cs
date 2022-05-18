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
			await this.SeedLedgerEntries();
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
				new { Id = Guid.Parse("44186c12-c48c-40ba-850e-6b4cc153f86a"), Name = "Jill" },
				new { Id = Guid.Parse("17fc72d5-c08f-4452-8cf4-395d40c83837"), Name = "ACME Widgets" },
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
				new { Id = Guid.Parse("d715a5c6-c9a2-4fcc-af03-781f684b9451"), Name = "Net salary" },
			};

			foreach (var category in categories)
			{
				if (await this.databaseContext.Categories.FindAsync(category.Id) == null)
				{
					await this.databaseContext.Categories.AddAsync(new Category { Id = category.Id, Name = category.Name });
				}
			}
		}

		private async Task SeedLedgerEntries()
		{
			var entries = new LedgerEntry[]
			{
				new ()
				{
					Id = Guid.Parse("783f502d-8239-4602-9f99-602c9b4755f1"),
					Amount = 45.26M,
					EntryDate = DateTime.Parse("5/11/2022"),
					IsIncome = false,
					CategoryId = Guid.Parse("c89d1d44-8719-47f5-8ab5-5281d005de3c"),
					PayeeId = Guid.Parse("8ae49976-52f5-45e9-b6f9-72d2e4daacbf"),
					LedgerId = Guid.Parse("6a58e91a-ec0d-447b-b958-0e0210208176"),
					Description = "Ledger entry 1",
				},
				new ()
				{
					Id = Guid.Parse("fd7e33c1-6610-4f82-884f-03850f4b6117"),
					Amount = 44.74M,
					EntryDate = DateTime.Parse("5/12/2022"),
					IsIncome = true,
					CategoryId = Guid.Parse("5311d853-b5ba-4880-adef-9e8e1085a541"),
					PayeeId = Guid.Parse("44186c12-c48c-40ba-850e-6b4cc153f86a"),
					LedgerId = Guid.Parse("6a58e91a-ec0d-447b-b958-0e0210208176"),
					Description = "Ledger entry 2",
				},
				new ()
				{
					Id = Guid.Parse("48dec574-1930-403e-8111-61e1127c0460"),
					Amount = 20M,
					EntryDate = DateTime.Parse("5/13/2022"),
					IsIncome = false,
					CategoryId = Guid.Parse("5311d853-b5ba-4880-adef-9e8e1085a541"),
					PayeeId = Guid.Parse("682ebc46-c7bb-4f1c-aef0-b6a00691279a"),
					LedgerId = Guid.Parse("6a58e91a-ec0d-447b-b958-0e0210208176"),
					Description = "Ledger entry 3",
				},
				new ()
				{
					Id = Guid.Parse("55ca669b-f693-4131-ae15-a4724f92dac1"),
					Amount = 7741.46M,
					EntryDate = DateTime.Parse("5/13/2022"),
					IsIncome = true,
					CategoryId = Guid.Parse("5311d853-b5ba-4880-adef-9e8e1085a541"),
					PayeeId = Guid.Parse("17fc72d5-c08f-4452-8cf4-395d40c83837"),
					LedgerId = Guid.Parse("6a58e91a-ec0d-447b-b958-0e0210208176"),
					Description = "Ledger entry 4",
				},
			};

			foreach (var ledgerEntry in entries)
			{
				if (await this.databaseContext.LedgerEntries.FindAsync(ledgerEntry.Id) == null)
				{
					await this.databaseContext.LedgerEntries.AddAsync(ledgerEntry);
				}
			}
		}
	}
}
