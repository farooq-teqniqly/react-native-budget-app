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

			var migrateOnStartup = builder.Configuration.GetValue<bool>("RunEFCoreMigrationsOnStartup");

			if (migrateOnStartup)
			{
				var retryPolicy = Policy
					.Handle<SqlException>()
					.WaitAndRetry(
						3,
						(_) => TimeSpan.FromSeconds(3));

				Console.WriteLine("MigrateOnStartup is true so running EF Core migrations...");
				var scope = app.Services.CreateScope();
				var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
				retryPolicy.Execute(() => databaseContext.Database.Migrate());
				Console.WriteLine("EF Core migrations complete.");
			}
			else
			{
				Console.WriteLine("Skipping EF Core migrations because MigrateOnStartup is false or not set.");
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