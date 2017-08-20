using System.Web.Http;
using WeatherReport.Api.Models;
using WeatherReport.Api.Services;

namespace WeatherReport.Api.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;

        /// <summary>
        /// Parameterized  constructor.
        /// </summary>
        /// <param name="weatherService"></param>
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        ///  Default constructor.
        /// </summary>
        public WeatherController()
        {
            _weatherService = new WeatherService();
        }

        /// <summary>
        /// Gets the Weather information by country and city.
        /// </summary>
        /// <param name="countryName"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [Route("Weather/{countryName}/{city}")]
        public IHttpActionResult Get([FromUri] string countryName, string city)
        {
            if (string.IsNullOrWhiteSpace(countryName))
                return BadRequest("Country Name must be provided");

            if (string.IsNullOrWhiteSpace(city))
                return BadRequest("City Name must be provided");

            var request = new GetWeatherReportRequest
            {
                Country = countryName,
                City = city
            };

            var weatherResponse = _weatherService.GetWeatherReport(request);

            if (weatherResponse == null)
                return NotFound();

            return Ok(weatherResponse);
        }
    }
}