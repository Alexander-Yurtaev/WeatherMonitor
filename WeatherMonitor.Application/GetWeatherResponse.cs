using WeatherMonitor.Domain;

namespace WeatherMonitor.Application;

public class GetWeatherResponse
{
    public WeatherData? Data { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;
}