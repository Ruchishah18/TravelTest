using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Database
{
    public interface IAirportDbContext : IDisposable
    {
        DbSet<Country> GeographyLevel1 { get; }
        DbSet<Airport> Airport { get; }
        DbSet<Route> Route { get; }
        DbSet<AirportGroup> AirportGroup { get; }
        DbSet<AirportsToAirportGroupsJoins> AirportsToAirportGroupsJoins { get; set; }
        Task SaveAsync();
    }
}