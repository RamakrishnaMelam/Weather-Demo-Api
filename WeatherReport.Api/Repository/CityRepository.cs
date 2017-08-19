using System.Collections.Generic;
using WeatherReport.Api.Models;

namespace WeatherReport.Api.Repository
{
    public class CityRepository
    {
        public List<CityModel> GetAllCitiesData()
        {
            List<CityModel> items = new List<CityModel>
            {
                new CityModel {Country = "Australia", City = "Sydney Airport"},
                new CityModel {Country = "Australia", City = "Melbourne Airport"},
                new CityModel {Country = "Australia", City = "Brisbane Airport"},
                new CityModel {Country = "Australia", City = "Perth Airport"},
                new CityModel {Country = "Australia", City = "Adelaide Airport"},
                new CityModel {Country = "Australia", City = "Gold Coast Airport"},
                new CityModel {Country = "Australia", City = "Newcastle Airport"},
                new CityModel {Country = "London", City = "Aberdeen Airport"},
                new CityModel {Country = "London", City = "Bangor Airport"},
                new CityModel {Country = "London", City = "Bath Airport"},
                new CityModel {Country = "India", City = "Hyderabad Airport"},
                new CityModel {Country = "India", City = "CHENNAI Airport"},
                new CityModel {Country = "India", City = "New Delhi Airport"}
            };
            return items;
        }
    }
}