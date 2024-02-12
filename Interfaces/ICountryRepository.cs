using DataAccess.Model;

namespace DataAccess.Interfaces
{
    public interface ICountryRepository
    {
        Task AddCountryAsync(Country country);
        Task<List<Country>> GetAllCountriesAsync();
        Task DeleteCountryAsync(int id);

    }
}
