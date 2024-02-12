using DataAccess.Interfaces;
using DataAccess.Model;
using IntuitiveTest.Interfaces;

namespace IntuitiveTest.Services
{
    public class CountryService(ICountryRepository country, IValidator<Country> validator) : ICountryService
    {
        private readonly ICountryRepository _country = country;
        private readonly IValidator<Country> _validator = validator;

        public async Task CreateCountryAsync(Country country)
        {
            await _validator.ValidateOnAddAsync(country);
            await _country.AddCountryAsync(country);
        }

        public async Task DeleteCountryByIdAsync(int id)
        {
            _validator.ValidateOnDelete(id);
            await _country.DeleteCountryAsync(id);
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _country.GetAllCountriesAsync();
                
        }

    }
}
