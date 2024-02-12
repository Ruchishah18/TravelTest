using DataAccess.Model;


namespace IntuitiveTest.Interfaces
{
    public interface ICountryService
    {
        Task CreateCountryAsync(Country country);
        Task<List<Country>> GetAllCountriesAsync();
        Task DeleteCountryByIdAsync(int id);
    }
}
