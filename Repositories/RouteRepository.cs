using DataAccess.Database;
using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RouteRepository(IAirportDbContext airportDbContext) : IRouteRepository
    {
        private readonly IAirportDbContext _airportDbContext = airportDbContext;

        public async Task AddRouteAsync(Route route)
        {
            await _airportDbContext.Route.AddAsync(route);
            await _airportDbContext.SaveAsync();
        }
        public async Task<List<Route>> GetAllRoutesAsync()
        {
            return await _airportDbContext.Route.ToListAsync()
                ?? throw new Exception("No routes exist");
        }
    }
}
