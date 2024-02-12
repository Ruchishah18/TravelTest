using DataAccess.Database;
using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CountryRepository(IAirportDbContext airportDbContext) : ICountryRepository
    {
        private readonly IAirportDbContext _airportDbContext = airportDbContext;

        public async Task AddCountryAsync(Country country)
        {
            await _airportDbContext.GeographyLevel1.AddAsync(country);
            await _airportDbContext.SaveAsync();
        }

        public async Task DeleteCountryAsync(int id)
        {
            var country = _airportDbContext.GeographyLevel1.FirstOrDefault(p => p.GeographyLevel1Id == id);
            _airportDbContext.GeographyLevel1.Remove(country);
            await _airportDbContext.SaveAsync();
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _airportDbContext.GeographyLevel1.ToListAsync()
                ?? throw new Exception("No countries exist");
        }


    }
}
