using System.Web.Http;
using WeatherReport.Api.Models;
using WeatherReport.Api.Services;

namespace WeatherReport.Api.Controllers
{
    public class CitiesController : ApiController
    {
        //Service interface declaration.
        private readonly IWeatherService _weatherService;

        /// <summary>
        /// Parameterized  constructor.
        /// </summary>
        /// <param name="weatherService"></param>
        public CitiesController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CitiesController()
        {
            _weatherService = new WeatherService();
        }

        /// <summary>
        /// Gets the cities by country.
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        [Route("Cities/{countryName}")]
        public IHttpActionResult Get([FromUri] string countryName)
        {
            //Request validation.
            if (string.IsNullOrWhiteSpace(countryName))
            {
                return BadRequest("Country Name must be provided");
            }

            var request = new GetCitiesByCountryRequest { Country = countryName };

            var cityList = _weatherService.GetCitiesByCountry(request);

            if (cityList == null)
                return NotFound();

            return Ok(cityList);
        }
    }
}