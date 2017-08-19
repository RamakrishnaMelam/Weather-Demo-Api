using System.Collections.Generic;
using WeatherReport.Api.Models;

namespace WeatherReport.Api.Services
{
    public interface IWeatherService
    {
        IEnumerable<CityModel> GetCitiesByCountry(GetCitiesByCountryRequest request);
        WeatherModel GetWeatherReport(GetWeatherReportRequest request);
    }
}