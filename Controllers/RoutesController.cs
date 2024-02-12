using AutoMapper;
using IntuitiveTest.Interfaces;
using IntuitiveTest.ViewModels;
using IntuitiveTest.Requests;
using Microsoft.AspNetCore.Mvc;
using Route = DataAccess.Model.Route;
using IntuitiveTest.ValidationOnRequest;

namespace IntuitiveTest.Controllers
{
    [ApiController]
    
    public class RoutesController(IRouteService routeService, IMapper mapper, CreateRouteRequestValidation validator) : ControllerBase
    {
        private readonly IRouteService _routeService = routeService;
        private readonly IMapper _mapper = mapper;
        private readonly CreateRouteRequestValidation _validator = validator;

        [HttpPost]
        [Route("routes")]
        public async Task<ActionResult> CreateRoute(CreateRouteRequest request)
        {
            var result = _validator.Validate(request);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _routeService.AddRouteAsync(_mapper.Map<Route>(request));
            return Ok();
        }
        [HttpGet]
        [Route("routes")]
        public async Task<ActionResult<List<RouteViewModel>>> GetAllRoutes()
        {
            var routes = await _routeService.GetAllRoutesAsync();
            return Ok(_mapper.Map<List<RouteViewModel>>(routes));
        }
    }
}
