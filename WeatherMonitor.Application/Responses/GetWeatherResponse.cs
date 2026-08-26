using WeatherMonitor.Domain.Data;

namespace WeatherMonitor.Application.Responses;

public class GetWeatherResponse
{
    public WeatherData? Data { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;
}