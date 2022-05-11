// Copyright (c) Farooq Mahmud

namespace Api
{
	using Api.Services;
	using DataAccess;
	using Microsoft.EntityFrameworkCore;

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

			var app = builder.Build();

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