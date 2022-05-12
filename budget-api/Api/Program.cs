// Copyright (c) Farooq Mahmud

namespace Api
{
	using Api.Services;
	using DataAccess;
	using Microsoft.Data.SqlClient;
	using Microsoft.EntityFrameworkCore;
	using Polly;

	internal class Program
	{
		internal static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("BudgetDb")));

			builder.Services.AddAutoMapper(typeof(MappingProfile));
			builder.Services.AddSingleton<IDateTimeService, DateTimeService>();

			builder.Services.AddScoped<IRepository, Repository>();

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
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}