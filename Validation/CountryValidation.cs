using DataAccess.Database;
using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Validation
{
    public class CountryValidation(IAirportDbContext airportDbContext) : IValidator<Country>
    {
        private readonly IAirportDbContext _airportDbContext = airportDbContext;

        public async Task ValidateOnAddAsync(Country model)
        {
            var isCountryExist = await _airportDbContext.GeographyLevel1.AnyAsync(p => p.Name == model.Name);
            if (isCountryExist)
            {
                throw new Exception("Country already exists");
            }
        }

        public void ValidateOnDelete(int id)
        {
            var isCountryExists = _airportDbContext.GeographyLevel1.Any(p => p.GeographyLevel1Id == id);
            if (!isCountryExists)
            {
                throw new Exception("Country could not be found");
            }
            var isCountryInUse = _airportDbContext.Airport.Any(p => p.GeographyLevel1Id == id);
            if (isCountryInUse)
            {
                throw new Exception("A country in use for an airport cannot be deleted");
            }
        }
    }
}
