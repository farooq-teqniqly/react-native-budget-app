// Copyright (c) Farooq Mahmud

namespace Api
{
	using DataAccess;
	using DataAccess.GraphQL.Mutations;
	using DataAccess.GraphQL.Queries;
	using DataAccess.GraphQL.Schemas;
	using DataAccess.GraphQL.Types;
	using DataAccess.Repositories;
	using GraphiQl;
	using GraphQL.Server;
	using GraphQL.Types;
	using Microsoft.Data.SqlClient;
	using Microsoft.EntityFrameworkCore;
	using Polly;
	using Services;

	/// <summary>
	/// The API entry point.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// The API entry point.
		/// </summary>
		/// <param name="args">Arguments to the program.</param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("BudgetDb")));

			builder.Services.AddSingleton<IDateTimeService, DateTimeService>();

			builder.Services.AddScoped<LedgerType>();
			builder.Services.AddScoped<CategoryType>();
			builder.Services.AddScoped<PayeeType>();
			builder.Services.AddScoped<LedgerEntryType>();

			builder.Services.AddScoped<LedgerInputType>();
			builder.Services.AddScoped<CategoryInputType>();
			builder.Services.AddScoped<PayeeInputType>();
			builder.Services.AddScoped<LedgerEntryInputType>();

			builder.Services.AddScoped<LedgerQuery>();
			builder.Services.AddScoped<LedgerEntryQuery>();
			builder.Services.AddScoped<CategoryQuery>();
			builder.Services.AddScoped<PayeeQuery>();
			builder.Services.AddScoped<RootQuery>();

			builder.Services.AddScoped<ILedgerRepository, LedgerRepository>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IPayeeRepository, PayeeRepository>();

			builder.Services.AddScoped<RootMutation>();
			builder.Services.AddScoped<LedgerMutation>();
			builder.Services.AddScoped<CategoryMutation>();
			builder.Services.AddScoped<PayeeMutation>();

			builder.Services.AddScoped<ISchema, RootSchema>();

#pragma warning disable CS0612 // Type or member is obsolete
			builder.Services.AddGraphQL(options =>
			{
				options.EnableMetrics = false;
			}).AddSystemTextJson();
#pragma warning restore CS0612 // Type or member is obsolete

			var app = builder.Build();

			var scope = app.Services.CreateScope();

			using (scope)
			{
				var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

				var retryPolicy = Policy
					.Handle<SqlException>()
					.WaitAndRetry(
						3,
						(_) => TimeSpan.FromSeconds(3));

				var deleteOnStartup = builder.Configuration.GetValue<bool>("DeleteDatabaseOnStartup");

				if (deleteOnStartup)
				{
					Console.WriteLine("DeleteDatabaseOnStartup is true so deleting database...");
					retryPolicy.Execute(() => databaseContext.Database.EnsureDeleted());
					Console.WriteLine("Database deleted.");
				}

				var migrateOnStartup = builder.Configuration.GetValue<bool>("RunEFCoreMigrationsOnStartup");

				if (migrateOnStartup)
				{
					Console.WriteLine("RunEFCoreMigrationsOnStartup is true so running EF Core migrations...");
					retryPolicy.Execute(() => databaseContext.Database.Migrate());
					Console.WriteLine("EF Core migrations complete.");
				}
				else
				{
					Console.WriteLine("Skipping EF Core migrations because RunEFCoreMigrationsOnStartup is false or not set.");
				}

				var seedDatabaseOnStartup = builder.Configuration.GetValue<bool>("RunDatabaseSeederOnStartup");

				if (seedDatabaseOnStartup)
				{
					Console.WriteLine("RunDatabaseSeederOnStartup is true so seeding database...");
					var seeder = new DatabaseSeeder(databaseContext);
					retryPolicy.Execute(() => seeder.SeedDatabaseAsync().Wait());
					Console.WriteLine("Database seeding complete.");
				}
				else
				{
					Console.WriteLine("Skipping seeding database because RunDatabaseSeederOnStartup is false or not set.");
				}
			}

			if (app.Environment.IsDevelopment())
			{
				app.UseGraphiQl("/graphql");
			}

			app.UseHttpsRedirection();
			app.UseGraphQL<ISchema>();
			app.Run();
		}
	}
}