using DataAccess.Database;
using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AirportRepository(IAirportDbContext airportDbContext) : IAirportRepository
    {
        private readonly IAirportDbContext _airportDbContext = airportDbContext;

        public async Task<Airport> GetAirportByIdAsync(int id)
        {
            return await _airportDbContext.Airport
                .Include(x => x.Country).FirstOrDefaultAsync(p => p.AirportId == id)
               ?? throw new Exception("Airport could not be found");
        }

        public async Task<List<Airport>> GetAllAirportsAsync()
        {
            return await _airportDbContext.Airport.ToListAsync()
                ?? throw new Exception("No airports found");

        }
    }
}
