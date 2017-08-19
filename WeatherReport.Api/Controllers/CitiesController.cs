using System.Web.Http;
using WeatherReport.Api.Models;
using WeatherReport.Api.Services;

namespace WeatherReport.Api.Controllers
{
    public class CitiesController : ApiController
    {
        private readonly IWeatherService _weatherService;

        public CitiesController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public CitiesController()
        {
            _weatherService = new WeatherService();
        }

        [Route("Cities/{countryName}")]
        public IHttpActionResult Get([FromUri]string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                return BadRequest("Country Name must be provided");
            }

            var request = new GetCitiesByCountryRequest()
            {
                Country = countryName
            };

            var cityList = _weatherService.GetCitiesByCountry(request);
            if (cityList == null)
            {
                return NotFound();
            }

            return Ok(cityList);
        }

    }
}
