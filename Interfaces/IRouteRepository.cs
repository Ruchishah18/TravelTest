using DataAccess.Model;

namespace DataAccess.Interfaces
{
    public interface IRouteRepository
    {
         Task<List<Route>> GetAllRoutesAsync();
         Task AddRouteAsync(Route route);
    }
}
