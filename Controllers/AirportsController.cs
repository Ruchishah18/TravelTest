using AutoMapper;
using IntuitiveTest.Interfaces;
using IntuitiveTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IntuitiveTest.Controllers
{
    [ApiController]
    
    public class AirportsController(IAirportService airportService, IMapper mapper) : ControllerBase
    {
        private readonly IAirportService _airportService = airportService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [Route("airports")]
        public async Task<ActionResult<AirportInfoMinimalViewModel>> GetAllAirport()
        {
            var airports = await _airportService.GetAllAirportsInfoAsync();

            return Ok(_mapper.Map<List<AirportInfoMinimalViewModel>>(airports));
        }
        [HttpGet]
        [Route("airports/{id}")]
        public async Task<ActionResult<AirportInfoViewModel>> GetAirport(int id)
        {
            if( id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var airport = await _airportService.GetAirportByIdAsync(id);

            return Ok(_mapper.Map<AirportInfoViewModel>(airport));
        }

    }
}
