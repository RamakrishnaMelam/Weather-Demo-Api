using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using WeatherReport.Api.GlobalWeatherServiceReference;
using WeatherReport.Api.Models;
using WeatherReport.Api.Repository;

namespace WeatherReport.Api.Services
{
    public class WeatherService : IWeatherService
    {
        #region Service Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<CityModel> GetCitiesByCountry(GetCitiesByCountryRequest request)
        {
            try
            {
                var client = new GlobalWeather();
                var result = client.GetCitiesByCountry("Australia");

                var theReader = new StringReader(result);
                var theDataSet = new DataSet();
                theDataSet.ReadXml(theReader);

                if (theDataSet.Tables.Count > 0)
                {
                    return theDataSet.Tables[0]
                        .AsEnumerable()
                        .Select(row => new CityModel
                        {
                            City = row.Field<string>("City"),
                            Country = row.Field<string>("Country")
                        });
                }

                return GetCitiesFromMockData(request);
            }
            catch (Exception)
            {
                return GetCitiesFromMockData(request);

            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WeatherModel GetWeatherReport(GetWeatherReportRequest request)
        {
            var response = new WeatherModel();
            try
            {
                var client = new GlobalWeather();
                var result = client.GetWeather(request.Country,request.City);

                if (result != null && result.Trim().Equals("Data Not Found"))
                    return GetWeatherReportFromMockData(request);

                if (result != null)
                {
                    var theReader = new StringReader(result);
                    var theDataSet = new DataSet();
                    theDataSet.ReadXml(theReader);
                    if (theDataSet.Tables.Count > 0)
                    {
                        return theDataSet.Tables[0]
                            .AsEnumerable()
                            .Select(row => new WeatherModel
                            {
                                Location = row.Field<string>("Location"),
                                Country = row.Field<string>("Country"),
                                Time = row.Field<string>("Time"),
                                Wind = row.Field<string>("Wind"),
                                SkyConditions = row.Field<string>("SkyConditions"),
                                Temperature = row.Field<string>("Temperature"),
                                Pressure = row.Field<string>("Pressure"),
                                DewPoint = row.Field<string>("DewPoint"),
                                RelativeHumidity = row.Field<string>("RelativeHumidity"),
                                Visibility = row.Field<string>("Visibility")
                            })
                            .FirstOrDefault();
                    }

                    return GetWeatherReportFromMockData(request);
                }
            }
            catch (Exception)
            {
                return GetWeatherReportFromMockData(request);
            }

            return response;
        }


        #endregion

        #region Private Methods
        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static WeatherModel GetWeatherReportFromMockData(GetWeatherReportRequest request)
        {
            var mockData = new WeatherRepository();
            return mockData
                .GetWeatherData()
                .FirstOrDefault(data => string.Equals(data.Country, request.Country, StringComparison.OrdinalIgnoreCase) &&
                                        string.Equals(data.Location, request.City, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static IEnumerable<CityModel> GetCitiesFromMockData(GetCitiesByCountryRequest request)
        {
            var mockData = new CityRepository();
            return mockData.GetAllCitiesData().Where(data => string.Equals(data.Country, request.Country,
                StringComparison.OrdinalIgnoreCase)).ToList();
        }

        #endregion

    }
}