using System.Collections.Generic;
using WeatherReport.Api.Models;

namespace WeatherReport.Api.Repository
{
    public class WeatherRepository
    {
        public List<WeatherModel> GetWeatherData()
        {

            return new List<WeatherModel> {
                new WeatherModel {   Country = "Australia", Location ="Sydney Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                            Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                            DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "Australia", Location ="Melbourne Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "Australia", Location ="Brisbane Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "Australia", Location ="Perth Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "Australia", Location ="Adelaide Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },
                new WeatherModel {   Country = "Australia", Location ="Gold Coast", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "Australia", Location ="Newcastle Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "Londan", Location ="Aberdeen Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "Londan", Location ="Bangor Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "Londan", Location ="Bath Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "India", Location ="Hyderabad Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "India", Location = "Chennai Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  },

                new WeatherModel {   Country = "India", Location ="New Delhi Airport", Time ="4:53 pm", Wind ="ENE 11km/h",
                    Visibility ="9mi", SkyConditions = "Clear Dark Sky", Temperature ="19.9°C",
                    DewPoint = "4.0°C", RelativeHumidity = "35%", Pressure ="1003.3hPa"  }
            };
        }
    }
}