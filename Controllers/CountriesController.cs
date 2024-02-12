using AutoMapper;
using DataAccess.Model;
using IntuitiveTest.Interfaces;
using IntuitiveTest.Requests;
using IntuitiveTest.ValidationOnRequest;
using IntuitiveTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IntuitiveTest.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class CountriesController(ILogger<CountriesController> logger,
        ICountryService country, IMapper mapper, CreateCountryRequestValidation validator) : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger = logger;
        private readonly ICountryService _country = country;
        private readonly IMapper _mapper = mapper;
        private readonly CreateCountryRequestValidation _validator = validator;

        [HttpPost]
        [Route("countries")]
        public async Task<ActionResult> CreateCountry(CreateCountryRequest request)
        {
            var result = _validator.Validate(request);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _country.CreateCountryAsync(_mapper.Map<Country>(request));
            return Ok();
        }
        [HttpGet]
        [Route("countries")]
        public async Task<ActionResult<CountryViewModel>> GetAllCountry()
        {
            var countries = await _country.GetAllCountriesAsync();
            return Ok(_mapper.Map<List<CountryViewModel>>(countries));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            await _country.DeleteCountryByIdAsync(id);
            return Ok();
        }
    }
}
