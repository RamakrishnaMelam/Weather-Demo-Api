namespace WeatherReport.Api.Models
{
    public class GetWeatherReportRequest
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}