using Route = DataAccess.Model.Route;

namespace IntuitiveTest.Interfaces
{
    public interface IRouteService 
    {
        Task<List<Route>> GetAllRoutesAsync();
        Task AddRouteAsync(Route route);
    }
}
