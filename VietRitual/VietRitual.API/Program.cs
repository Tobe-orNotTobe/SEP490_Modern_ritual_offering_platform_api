using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VietRitual.Common.Helper;
using VietRitual.Data.Entities;
using VietRitual.Data.Models;
using VietRitual.Data.Seeders;
using VietRitual.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddServices(builder.Configuration);


builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		builder =>
		{
			builder.AllowAnyOrigin()
				   .AllowAnyMethod()
				   .AllowAnyHeader();
		});
});


var app = builder.Build();

// Seed data when application starts
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var context = services.GetRequiredService<VietRitualDBContext>();
		var userManager = services.GetRequiredService<UserManager<User>>();
		var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

		await context.Database.MigrateAsync();

		await VietRitualDataSeeder.SeedAsync(context, userManager, roleManager);

		Console.WriteLine("✅ Data seeding completed successfully!");
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "❌ An error occurred while seeding the database.");
	}
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
