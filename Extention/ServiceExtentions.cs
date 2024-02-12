using DataAccess.Database;
using DataAccess.Interfaces;
using DataAccess.Model;
using DataAccess.Repositories;
using DataAccess.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extention
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAirportDataBase(this IServiceCollection services, string connectionString)
        {

            return services.AddDbContext<AirportDbContext>(options =>
                      options.UseSqlServer(connectionString))
              .AddScoped<IAirportDbContext>(d => d.GetRequiredService<AirportDbContext>())
              .AddScoped<ICountryRepository,CountryRepository>()
              .AddScoped<IAirportRepository, AirportRepository>()
              .AddScoped<IRouteRepository, RouteRepository>()
              .AddScoped<IValidator<Route>, RouteValidation>()
              .AddScoped<IValidator<Country>, CountryValidation>();
        }
    }
}
