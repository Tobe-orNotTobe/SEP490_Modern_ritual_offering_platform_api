using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VietRitual.Data.Entities;
using VietRitual.Data.Models;

namespace VietRitual.Repository
{
	public static class DatabaseConfiguration
	{
		public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			// Register DbContext
			services.AddDbContext<VietRitualDBContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
	}
}
