using DataAccess.Model;

namespace IntuitiveTest.Interfaces
{
    public interface IAirportService
    {
        Task<Airport> GetAirportByIdAsync(int airportId);
        Task<List<Airport>> GetAllAirportsInfoAsync();
    }
}
