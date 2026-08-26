using WeatherMonitor.Domain.Dto;
using WeatherMonitor.Domain.Data;

namespace WeatherMonitor.Tests.Helpers;

public static class TestHelpers
{
    public static WeatherDto GetWeatherDto()
    {
        return new WeatherDto
        {
            Location = new LocationDto { Name = "Москва" },
            Current = new CurrentDto
            {
                LastUpdated = "2026-08-25 23:45",
                Temperature = 13.2,
                Condition = new ConditionDto
                {
                    Text = "Пасмурно",
                    Icon = "//cdn.weatherapi.com/weather/64x64/night/122.png"
                },
                FeelsLike = 10,
                Humidity = 84,
                Wind = 14.4,
                Visibility = 10
            },
            Forecast = new ForecastDto
            {
                Forecastday =
                [
                    new ForecastdayDto
                    {
                        Date = "2026-08-26",
                        Day = new DayDto
                        {
                            MaxTemperature = 15.3,
                            MinTemperature = 12.3,
                            Condition = new ConditionDto
                            {
                                Text = "Patchy rain nearby",
                                Icon = "//cdn.weatherapi.com/weather/64x64/day/176.png"
                            }
                        }
                    }
                ]
            }
        };
    }

    public static WeatherData GetWeatherData()
    {
        return new WeatherData
        {
            Location = new Location { Name = "Москва" },
            Current = new Current
            {
                LastUpdated = "2026-08-25 23:45",
                Temperature = 13,
                Condition = new Condition
                {
                    Text = "Пасмурно",
                    Icon = "//cdn.weatherapi.com/weather/64x64/night/122.png"
                },
                FeelsLike = 10,
                Humidity = 84,
                Wind = 14.4,
                Visibility = 10
            },
            Forecast = new Forecast
            {
                Forecastday =
                [
                    new Forecastday
                    {
                        Date = "2026-08-26",
                        Day = new Day
                        {
                            MaxTemperature = 15.3,
                            MinTemperature = 12.3,
                            Condition = new Condition
                            {
                                Text = "Patchy rain nearby",
                                Icon = "//cdn.weatherapi.com/weather/64x64/day/176.png"
                            }
                        }
                    }
                ]
            }
        };
    }

    public static string GetJsonData()
    {
        return @"
{
  ""location"": {
    ""name"": ""Москва""
  },
  ""current"": {
    ""last_updated"": ""2026-08-25 23:45"",
    ""temp_c"": 13.2,
    ""condition"": {
      ""text"": ""Пасмурно"",
      ""icon"": ""//cdn.weatherapi.com/weather/64x64/night/122.png""
    },
    ""feelslike_c"": 10,
    ""humidity"": 84,
    ""wind_kph"": 14.4,
    ""vis_km"": 10
  },
  ""forecast"": {
    ""forecastday"": [
      {
        ""date"": ""2026-08-26"",
        ""day"": {
          ""maxtemp_c"": 15.3,
          ""mintemp_c"": 12.3,
          ""condition"": {
            ""text"": ""Patchy rain nearby"",
            ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
          }
        },
        ""hour"": [
          {
            ""time"": ""2026-08-26 00:00"",
            ""temp_c"": 12.5,
            ""condition"": {
              ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
            }
          },
          {
            ""time"": ""2026-08-26 00:00"",
            ""temp_c"": 12.5,
            ""condition"": {
              ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
            }
          }
        ]
      },
      {
        ""date"": ""2026-08-27"",
        ""day"": {
          ""maxtemp_c"": 15.3,
          ""mintemp_c"": 12.3,
          ""condition"": {
            ""text"": ""Patchy rain nearby"",
            ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
          }
        },
        ""hour"": [
          {
            ""time"": ""2026-08-26 00:00"",
            ""temp_c"": 12.5,
            ""condition"": {
              ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
            }
          },
          {
            ""time"": ""2026-08-26 00:00"",
            ""temp_c"": 12.5,
            ""condition"": {
              ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
            }
          }
        ]
      },
      {
        ""date"": ""2026-08-28"",
        ""day"": {
          ""maxtemp_c"": 15.3,
          ""mintemp_c"": 12.3,
          ""condition"": {
            ""text"": ""Patchy rain nearby"",
            ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
          }
        },
        ""hour"": [
          {
            ""time"": ""2026-08-26 00:00"",
            ""temp_c"": 12.5,
            ""condition"": {
              ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
            }
          },
          {
            ""time"": ""2026-08-26 00:00"",
            ""temp_c"": 12.5,
            ""condition"": {
              ""icon"": ""//cdn.weatherapi.com/weather/64x64/day/176.png""
            }
          }
        ]
      }
    ]
  }
}";
    }
}
