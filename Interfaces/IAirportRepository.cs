using DataAccess.Model;

namespace DataAccess.Interfaces
{
    public interface IAirportRepository
    {
        Task<Airport> GetAirportByIdAsync(int id);
        Task<List<Airport>> GetAllAirportsAsync();

    }
}
