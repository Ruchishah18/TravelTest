using DataAccess.Interfaces;
using IntuitiveTest.Interfaces;
using Route = DataAccess.Model.Route;

namespace IntuitiveTest.Services
{
    public class RouteService(IRouteRepository routeRepository,
        IValidator<Route> validator) : IRouteService
    {
        private readonly IRouteRepository _routeRepository = routeRepository;
        private readonly IValidator<Route> _validator = validator;

        public async Task AddRouteAsync(Route route)
        {
            await _validator.ValidateOnAddAsync(route);
            await _routeRepository.AddRouteAsync(route);
        }
        public async Task<List<Route>> GetAllRoutesAsync()
        {
            return await _routeRepository.GetAllRoutesAsync();
        }
    }
}
