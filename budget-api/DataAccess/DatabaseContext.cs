// Copyright (c) Farooq Mahmud

#pragma warning disable CS8618
namespace DataAccess
{
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;

	/// <summary>
	/// The Entity Framework database context.
	/// </summary>
	public class DatabaseContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseContext"/> class.
		/// </summary>
		public DatabaseContext()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DatabaseContext"/> class.
		/// </summary>
		/// <param name="options">The options object used to configure the data context.</param>
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}

		/// <summary>
		/// Gets or sets the ledgers DbSet.
		/// </summary>
		public DbSet<Ledger> Ledgers { get; set; }
		public DbSet<LedgerEntry> LedgerEntries { get; set; }

		/// <summary>
		/// Gets or sets the categories DbSet.
		/// </summary>
		public DbSet<Category> Categories { get; set; }

		/// <summary>
		/// Gets or sets the payees DbSet.
		/// </summary>
		public DbSet<Payee> Payees { get; set; }

		/// <inheritdoc />
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
		}

		/// <inheritdoc />
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var configuration = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json")
					.AddUserSecrets(typeof(DatabaseContext).Assembly)
					.Build();

				var connectionString = configuration.GetConnectionString("BudgetDb");

				optionsBuilder.UseSqlServer(connectionString);
			}
		}
	}
}
