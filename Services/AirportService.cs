
using DataAccess.Interfaces;
using DataAccess.Model;
using IntuitiveTest.Interfaces;

namespace IntuitiveTest.Services
{
    public class AirportService(IAirportRepository repository) : IAirportService
    {
        private readonly IAirportRepository _repository = repository;

        public async Task<Airport> GetAirportByIdAsync(int airportId)
        {
            return await _repository.GetAirportByIdAsync(airportId);
        }

        public async Task<List<Airport>> GetAllAirportsInfoAsync()
        {
            return await _repository.GetAllAirportsAsync();
               
        }
    }
}
