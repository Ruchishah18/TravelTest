using DataAccess.Database;
using DataAccess.Interfaces;
using DataAccess.Model;
using DataAccess.Model.Enum;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Validation
{
    public class RouteValidation(IAirportDbContext airportDbContext) : IValidator<Route>
    {
        private readonly IAirportDbContext _airportDbContext = airportDbContext;
        public async Task ValidateOnAddAsync(Route model)
        {
            await IsRouteExist(model);
            await IsAirportGroupIdsExist(model);
            await IsValidChoiseAirportType(model);

        }

        private async Task IsValidChoiseAirportType(Route model)
        {
            var joinsData = await _airportDbContext.AirportsToAirportGroupsJoins.ToListAsync();
            var airports = await _airportDbContext.Airport.ToListAsync();
            // List of Ids of arrival and departure airports
            var arrivalAirportIds = joinsData.Where(p => p.AirportGroupId == model.ArrivalAirportGroupId).Select(p => p.AirportId).ToList();
            var departureAirportIds = joinsData.Where(p => p.AirportGroupId == model.DepartureAirportGroupId).Select(p => p.AirportId);

            // Check for arrival airport type  matched or not
            if (arrivalAirportIds.Any())
            {
                var matchedAirports = airports.Where(p => arrivalAirportIds.Contains(p.AirportId));
                if (!(matchedAirports.Any(p => p.Type == AirportType.ArrivalOnly)
                      || matchedAirports.Any(p => p.Type == AirportType.DepartureAndArrival)))
                    throw new Exception("Route is Invalid");
            }
            else
            {
                throw new Exception("Arrival airport group id is not related to any airport");
            };
            // Check for departure airport type matched or not
            if (departureAirportIds.Any())
            {
                var matchedAirports = airports.Where(p => departureAirportIds.Contains(p.AirportId));
                if (!(matchedAirports.Any(p => p.Type == AirportType.DepartureOnly)
                     || matchedAirports.Any(p => p.Type == AirportType.DepartureAndArrival)))
                    throw new Exception("Route is Invalid");
            }
            else
            {
                throw new Exception("Departure airport group id is not related to any airport");
            };
        }

        private async Task IsAirportGroupIdsExist(Route model)
        {
            var airportGroups = await _airportDbContext.AirportGroup.ToListAsync();
            var IsAirpotGroupExistforArrival = airportGroups.Where(p => p.AirportGroupId == model.ArrivalAirportGroupId);
            var IsAirpotGroupExistforDeparture = airportGroups.Where(p => p.AirportGroupId == model.DepartureAirportGroupId);

            if (!IsAirpotGroupExistforArrival.Any() || !IsAirpotGroupExistforDeparture.Any())
            {
                throw new Exception("The airport group could not be found");
            }
        }

        private async Task IsRouteExist(Route model)
        {
            var routes = await _airportDbContext.Route.ToListAsync();
            if (routes.Any(p => p.ArrivalAirportGroupId == model.ArrivalAirportGroupId && p.DepartureAirportGroupId == model.DepartureAirportGroupId))
            {
                throw new Exception("The route is already exists");
            }
        }

        public void ValidateOnDelete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
